using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSManager : MonoBehaviour
{
    private float fps;

    [SerializeField]
    private Text textField;

    void Update()
    {
        fps = 1.0f / Time.deltaTime;
        fps = Mathf.Round(fps);
        textField.text = fps.ToString();
    }
}
