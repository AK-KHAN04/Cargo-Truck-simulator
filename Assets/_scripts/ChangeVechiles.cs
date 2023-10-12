using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVechiles : MonoBehaviour
{
    [SerializeField]
    private GameObject oldTruck, newTruck, Panel;



    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Helo world" + col.gameObject.name);
        if (col.CompareTag("Player"))
        {

            //newTruck.GetComponent<Rigidbody>().isKinematic = true;
            //newTruck.GetComponent<RCC_CarControllerV3>().enabled = false;


            Panel.SetActive(true);
            col.gameObject.SetActive(false);
            Invoke(nameof(DeactivatePanel), 2f);
        }
    }

    private void DeactivatePanel()
    {
        //newTruck = HillEnvLevelManager.instance.trucks[HillEnvLevelManager.instance.currentLevel];
        HillEnvLevelManager.instance.trucks[HillEnvLevelManager.instance.currentLevel].SetActive(false);
        //newTruck.SetActive(true);


        HillEnvLevelManager.instance.truckWithJointClone = RCC.SpawnRCC(HillEnvLevelManager.instance.truckWithJoint, HillEnvLevelManager.instance.SpawnPoints[HillEnvLevelManager.instance.currentLevel].transform.position, HillEnvLevelManager.instance.SpawnPoints[HillEnvLevelManager.instance.currentLevel].transform.rotation, true, true, true);
        //bl_MiniMap.ActiveMiniMap.Target = HillEnvLevelManager.instance.truckWithJointClone.GetComponent<Transform>();

        /*   HillEnvLevelManager.instance.trucks[HillEnvLevelManager.instance.currentLevel].transform.SetPositionAndRotation
              (HillEnvLevelManager.instance.SpawnPoints[HillEnvLevelManager.instance.currentLevel].transform.position,
               HillEnvLevelManager.instance.SpawnPoints[HillEnvLevelManager.instance.currentLevel].transform.rotation);*/

        Panel.SetActive(false);

        //newTruck.GetComponent<Rigidbody>().isKinematic = false;
        //newTruck.GetComponent<RCC_CarControllerV3>().enabled = true;
    }

}


