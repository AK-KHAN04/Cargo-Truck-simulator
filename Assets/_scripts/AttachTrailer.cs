using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachTrailer : MonoBehaviour
{

    public ConfigurableJoint joint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.gameObject);
           // this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            joint.connectedBody = FindAnyObjectByType<RCC_CarControllerV3>().GetComponent<Rigidbody>();
        }
    }
}
