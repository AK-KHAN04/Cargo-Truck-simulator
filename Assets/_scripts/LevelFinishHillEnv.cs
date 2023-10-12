using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinishHillEnv : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("You have completed a mission");
        //HillEnvLevelManager.instance.trucks[HillEnvLevelManager.instance.currentLevel].SetActive(false);
        Destroy(GameObject.Find("TruckWithJoint"));
        Destroy(HillEnvLevelManager.instance.truckWithJointClone.gameObject);
        HillEnvLevelManager.instance.NextLevel();
    }


    
}
