using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Level;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public static int selectedLevel;
    public List<Level> levels = new List<Level>();

    private void Awake()
    {
        Debug.Log("Hello workd");
        instance = this;
        for (int i = 0; i < PlayerPrefs.GetInt(GameConstants.CURRENT_SELECTED_LEVEL); i++)
        {
            Debug.Log(i);
            levels[i].Status = LevelStatus.Unlocked;
        }

        selectedLevel = PlayerPrefs.GetInt(GameConstants.CURRENT_SELECTED_LEVEL) + 1;
        levels[selectedLevel - 1].Status = LevelStatus.Available;
        levels[selectedLevel].Status = LevelStatus.Rewarded;
    }




    // Call this function to unlock a level
    public void UnlockLevel(int levelNumber)
    {
        Level level = levels.Find(l => l.LevelNumber == levelNumber);
        if (level != null)
        {
            level.Status = LevelStatus.Unlocked;
            level.UpdateStatus();
        }
    }

    // Call this function to make a level available for play
    public void MakeLevelAvailable(int levelNumber)
    {
        Level level = levels.Find(l => l.LevelNumber == levelNumber);
        if (level != null)
        {
            level.Status = LevelStatus.Available;
        }
    }

    public void MakePreviousSelectedLevelToUnlocked()
    {
        Level level = levels.Find(l => l.LevelNumber == selectedLevel);
        if (level != null)
        {
            Debug.Log(selectedLevel);
            level.Status = LevelStatus.Unlocked;
            level.UpdateStatus();
        }
    }

    // Call this function to get the status of a level
    public LevelStatus GetLevelStatus(int levelNumber)
    {
        Level level = levels.Find(l => l.LevelNumber == levelNumber);
        if (level != null)
        {
            return level.Status;
        }
        return LevelStatus.Locked; // Default status if level is not found
    }


    public void PlayBtnClick()
    {
        PlayerPrefs.SetInt(GameConstants.CURRENT_SELECTED_LEVEL, selectedLevel - 1);
        TopBarManager.instance.LevelSelectionPanel.SetActive(false);
        TopBarManager.instance.TruckSelectionPanel.SetActive(true);
    }
}
