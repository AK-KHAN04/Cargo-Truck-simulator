using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Level : MonoBehaviour
{
        // Additional data if needed
    public int LevelNumber;
    public LevelStatus Status;
    public GameObject unlocked, available, locked, rewarded;



    public enum LevelStatus
    {
        Locked,
        Unlocked,
        Available,
        Rewarded
    }

    private void OnEnable()
    {
        UpdateStatus();
    }
    public void Levelstatus()
    {
        switch (Status)
        {
            case LevelStatus.Locked:
                Debug.Log("Locked");
                break;

            case LevelStatus.Unlocked:
                LevelManager.instance.MakePreviousSelectedLevelToUnlocked();
                LevelManager.selectedLevel = LevelNumber;
                Status = LevelStatus.Available;
                UpdateStatus();
                break;

            case LevelStatus.Available:
                LevelManager.selectedLevel = LevelNumber;
                break;

            case LevelStatus.Rewarded:
                Debug.Log("Watch A video to open the level");
                break;

            default:
                Debug.Log("Invalid Input");
                break;
        }

    }


    public void UpdateStatus()
    {
        unlocked.SetActive(Status == LevelStatus.Unlocked);
        available.SetActive(Status == LevelStatus.Available);
        locked.SetActive(Status == LevelStatus.Locked);
        rewarded.SetActive(Status == LevelStatus.Rewarded);
    }

}
