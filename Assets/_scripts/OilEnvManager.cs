using InsaneSystems.RoadNavigator;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OilEnvManager : MonoBehaviour
{
    public static OilEnvManager instance;
    public Text levelText;
    public Text instructionText;

    public RCC_CarControllerV3[] trucks, oilTrucks;

    public OilLevel[] level;

    public GameObject instructionPanel, levelFailedPanel, levelCompletePanel, loadingPanel;
    public int currentLevel, currentTruck;


    private void Awake()
    {
        instance = this;
       
    }


    public void Start()
    {
        foreach (OilLevel i in level)
        {
            i.gameObject.SetActive(false);
        }
        //Getting Level Information and setting the level setup for the Environment
        if (PlayerPrefs.HasKey(GameConstants.CURRENT_SELECTED_LEVEL))
        {
            currentLevel = PlayerPrefs.GetInt(GameConstants.CURRENT_SELECTED_LEVEL);

        }
        else
        {
            currentLevel = 0;
            Debug.Log("There is no value in the playerPrefs");
        }
        levelText.text = (currentLevel + 1).ToString();


        //setting the truck from playerprefs
        if (PlayerPrefs.HasKey(GameConstants.TRUCK_SELECTED))
        {
            currentTruck = PlayerPrefs.GetInt(GameConstants.TRUCK_SELECTED);
        }
        else
        {
            currentTruck = 0;
        }

        //setting the selected truck active and its position to the level starting position
        level[currentLevel].gameObject.SetActive(true);
        SpawnTruck();
        

    }


    public void NextLevel()
    {
        ShowInstructionPanel("Level is Loading", true);
        level[currentLevel].gameObject.SetActive(false);
        FindAnyObjectByType<RCC_CarControllerV3>().gameObject.SetActive(false);
        currentLevel++;
        PlayerPrefs.SetInt(GameConstants.CURRENT_SELECTED_LEVEL, currentLevel);
        PlayerPrefs.SetInt(GameConstants.CURRENT_UNLOCKED_LEVEL, currentLevel);
        level[currentLevel].gameObject.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void SpawnTruck()
    {
        if (currentLevel == 0)
        {
            RCC.SpawnRCC(trucks[currentTruck], level[currentLevel].startPoint.position, level[currentLevel].startPoint.rotation, true, true, false);
        }
        else
        {
            RCC.SpawnRCC(oilTrucks[currentTruck], level[currentLevel].startPoint.position, level[currentLevel].startPoint.rotation, true, true, false);
        }
    }

    public void ShowInstructionPanel(string text, bool SelfDeactivate)
    {
        instructionPanel.SetActive(true);
        instructionText.text = text;
        if (SelfDeactivate)
        {
            Invoke(nameof(DisableInstructionPanel), 2f);
        }
    }

    public void DisableInstructionPanel()
    {
        instructionPanel.SetActive(false);
    }
}



