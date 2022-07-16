using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InDamageModule : CharacterBase
{
    [Header("Heal Point")]
    [SerializeField] private float currentHeal = 100.0f;
    [SerializeField] private float maxHeal = 100.0f;
    [SerializeField] private Text healText;

    [Header("Shield Point")]
    [SerializeField] private float currentShield = 20.0f;
    [SerializeField] private float maxShield = 20.0f;
    [SerializeField] private Text shieldText;

    [Header("Visualiling")]
    [SerializeField] private ParticleSystem inDamageParticle;
    [SerializeField] private Slider healPointBar;
    [SerializeField] private Slider shieldPointBar;

    [SerializeField] private ParticleSystem shieldDestroyParticle;

    public UnityEvent deach;

    /// Обьект который нанес Урон
    private Transform objectDamage;

    private void Start()
    {
        currentHeal = maxHeal;
        healPointBar.maxValue = maxHeal;
        healPointBar.value = currentHeal;
        if (healText) healText.text = currentHeal.ToString();

        currentShield = maxShield;
        shieldPointBar.maxValue = maxShield;
        shieldPointBar.value = currentShield;
        if (shieldText) shieldText.text = currentShield.ToString();

        StartCoroutine(WaitStart());
    }

    bool gameIsPlayer = false;
    private IEnumerator WaitStart()
    {
        yield return new WaitForSeconds(0.5f);

        gameIsPlayer = true;
    }

    public void InDamage(float damage, RaycastHit hit, Transform objectDamage = null)
    {
        if (currentHeal <= 0) return;
        this.objectDamage = objectDamage;     // Solo

        if (state != SupportClass.gameState.client && state != SupportClass.gameState.clone)
        {
            if (currentShield <= 0)
                currentHeal -= damage;
            else
            {
                currentShield -= damage * 0.75f;
                currentHeal -= damage * 0.25f;

                if (currentShield <= 0 && shieldDestroyParticle != null)
                    shieldDestroyParticle.Play();
            }

            if (healPointBar != null) healPointBar.value = currentHeal;
            if (healText) healText.text = Mathf.CeilToInt(Mathf.Clamp(currentHeal, 0, 1000000)).ToString();

            if (shieldPointBar != null) shieldPointBar.value = currentShield;
            if (shieldText) shieldText.text = Mathf.CeilToInt(Mathf.Clamp(currentShield, 0, 1000000)).ToString();

            if (currentHeal <= 0)
                Deach();
        }

        if (hit.collider != null && inDamageParticle != null)
        {
            inDamageParticle.transform.position = hit.point;
            inDamageParticle.Play();
        }
    }

    public void InDamageAfterFall(float damage)
    {
        if (currentHeal <= 0) return;

        if (state != SupportClass.gameState.client && state != SupportClass.gameState.clone)
        {
            currentHeal -= damage;

            if (healPointBar != null) healPointBar.value = currentHeal;
            if (healText) healText.text = Mathf.CeilToInt(Mathf.Clamp(currentHeal, 0, 1000000)).ToString();

            if (currentHeal <= 0)
                Deach();
        }
    }

    private void Deach()
    {
        deach.Invoke();
        if (playerAnim)
        {
            playerAnim.SetTrigger("Die");
        }
    }

    public float GetHeal()
    {
        return currentHeal;
    }

    public void SetHeal(float newHP)
    {
        if (!gameIsPlayer || currentHeal <= 0) return;

        currentHeal = newHP;
        if (healPointBar != null) healPointBar.value = currentHeal;
        if (healText) healText.text = Mathf.CeilToInt(Mathf.Clamp(currentHeal, 0, 1000000)).ToString();

        if (currentHeal <= 0)
            Deach();
    }

    public void SetShield(float newShield)
    {
        if (!gameIsPlayer || currentHeal <= 0) return;

        currentShield = newShield;
        if (shieldPointBar != null) shieldPointBar.value = currentShield;
        if (shieldText) shieldText.text = Mathf.CeilToInt(Mathf.Clamp(currentShield, 0, 1000000)).ToString();
    }

    public float GetShield()
    {
        return currentShield;
    }

    public void ReloadParam()
    {
        currentHeal = maxHeal;
        currentShield = maxShield;

        SetHeal(maxHeal);
        SetShield(maxShield);

        //if (healPointBar != null) startHealVisual = healPointBar.rect.width;
        //if (shieldPointBar != null) startShieldVisual = shieldPointBar.rect.width;
    }

    /// Возвращает Обьект который нанес Урон
    /// SOLO
    public Transform GetTarget()
    {
        return objectDamage;
    }
}
