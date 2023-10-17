using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class OilLevelFinished : MonoBehaviour
{
    public GameObject actualCamera;
    public GameObject visuals;
    public GameObject[] virtualCameras;
    private void OnTriggerEnter(Collider other)
    {
            
        actualCamera.SetActive(false);
        visuals.SetActive(false);
        FindAnyObjectByType<RCC_CarControllerV3>().gameObject.SetActive(false);
        foreach(GameObject i in virtualCameras)
        {
            i.SetActive(true);
        }
    }
}
