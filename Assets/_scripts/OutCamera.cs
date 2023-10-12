using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutCamera : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Let the Camera Rolls out");

        RCC_Camera.instance.TPSHeight = 4;
        RCC_Camera.instance.TPSDistance = 10;
        RCC_Camera.instance.TPSPitch = 15;
    }
}
