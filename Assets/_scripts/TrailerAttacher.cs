using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailerAttacher : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("attach"))
        {
            CityEnvManager.instance.ChangeTrucks();
        }
    }
}
