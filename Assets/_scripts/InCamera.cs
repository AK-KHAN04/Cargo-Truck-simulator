using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InCamera : MonoBehaviour
{
 
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Let the camera Rolls in");

        RCC_Camera.instance.TPSHeight = 5;
        RCC_Camera.instance.TPSDistance = 8;
        RCC_Camera.instance.TPSPitch = 25;
    }
}
