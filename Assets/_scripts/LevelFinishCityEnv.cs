using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinishCityEnv : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        CityEnvManager.instance.ShowInstructionPanel("Level Completed", true);
        FindAnyObjectByType<RCC_CarControllerV3>().gameObject.GetComponent<Rigidbody>().isKinematic = true;
        CityEnvManager.instance.LevelComplete();
    }


    
    
}
