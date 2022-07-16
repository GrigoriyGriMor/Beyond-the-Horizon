using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveObjectController : MonoBehaviour
{
    [SerializeField] private float destroyTime = 2;

    [Header("FORCE")]
    [SerializeField] private float forwardForce = 50.0f;

    [SerializeField] private bool needRoatate = false;
    [SerializeField] private float rotateForce = 5.0f;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        if (_rb != null) _rb.isKinematic = false;
        StartCoroutine(Startmove());
    }

    private IEnumerator Startmove()
    {
        yield return new WaitForFixedUpdate();

        if (_rb != null)
        {
            _rb.AddForce(transform.forward * forwardForce);
            if (needRoatate) _rb.AddTorque(new Vector3(0, rotateForce, rotateForce));
        }
        StartCoroutine(TimerDestroy());
    }

    [SerializeField] private bool destroyOrDeactive = false;
    private IEnumerator TimerDestroy()
    {
        yield return new WaitForSeconds(destroyTime);

        if (_rb != null) _rb.isKinematic = true;
        if (!destroyOrDeactive) gameObject.SetActive(false);
        else Destroy(gameObject);
        transform.position = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_rb != null) _rb.isKinematic = true;
        gameObject.SetActive(false);
        transform.position = Vector3.zero;
    }
}
