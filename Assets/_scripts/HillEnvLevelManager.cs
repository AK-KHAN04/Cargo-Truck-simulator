using InsaneSystems.RoadNavigator;
using UnityEngine;
using UnityEngine.UI;

public class HillEnvLevelManager : MonoBehaviour
{
    public static HillEnvLevelManager instance;
    public int currentLevel;

    public GameObject[] LevelPaths, SpawnPoints;
    public GameObject  blackPanel, instructionPanel;
    public Text instructionText;
    public GameObject[] trucks;

    public RCC_CarControllerV3 truckWithJoint;
    public RCC_CarControllerV3 truckWithJointClone;

    public string nextLevelName; // Change this to the name of your next level scene



    private void Awake()
    {
        instance = this;        
    }
    private void Start()
    {
        
        //Showing instructions to user for some time
        ShowInstructionPanel("Carry the logs to the destination");

        currentLevel =  PlayerPrefs.GetInt(GameConstants.CURRENT_SELECTED_LEVEL);

        Debug.Log(currentLevel);



        trucks[currentLevel].SetActive(true);

        LevelPaths[currentLevel].SetActive(true);

        Debug.Log(PlayerPrefs.GetInt(GameConstants.CURRENT_SELECTED_LEVEL));
    }


    public void ShowInstructionPanel(string text)
    {
        instructionPanel.SetActive(true);
        instructionText.text = text;
        Invoke(nameof(DisableInstructionPanel), 2f);
    }
    public void DisableInstructionPanel()
    {
        instructionPanel.SetActive(false);
    }


    #region Level Finish For Hill Environment
    public void NextLevel()
    {

        HillEnvLevelManager.instance.LevelPaths[HillEnvLevelManager.instance.currentLevel].SetActive(false);
        if (HillEnvLevelManager.instance.currentLevel < 6)
        {
            HillEnvLevelManager.instance.currentLevel++;
        }

        //Setting the Level prefs one value increment
        PlayerPrefs.SetInt(GameConstants.CURRENT_SELECTED_LEVEL, HillEnvLevelManager.instance.currentLevel);
        if (PlayerPrefs.GetInt(GameConstants.CURRENT_UNLOCKED_LEVEL) < HillEnvLevelManager.instance.currentLevel)
        {
            PlayerPrefs.SetInt(GameConstants.CURRENT_UNLOCKED_LEVEL, HillEnvLevelManager.instance.currentLevel);
        }


        HillEnvLevelManager.instance.LevelPaths[HillEnvLevelManager.instance.currentLevel].SetActive(true);
        HillEnvLevelManager.instance.trucks[HillEnvLevelManager.instance.currentLevel].SetActive(true);
        HillEnvLevelManager.instance.trucks[HillEnvLevelManager.instance.currentLevel].SetActive(false);

        //setting position and rotation towards the next spawn point
        HillEnvLevelManager.instance.trucks[HillEnvLevelManager.instance.currentLevel].transform.SetPositionAndRotation
            (HillEnvLevelManager.instance.SpawnPoints[HillEnvLevelManager.instance.currentLevel].transform.position,
             HillEnvLevelManager.instance.SpawnPoints[HillEnvLevelManager.instance.currentLevel].transform.rotation);


        HillEnvLevelManager.instance.trucks[HillEnvLevelManager.instance.currentLevel].SetActive(true);
        HillEnvLevelManager.instance.ShowInstructionPanel("You are playing " + nextLevelName + " and now carry the log the next level");

    }
    #endregion
}
