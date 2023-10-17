using InsaneSystems.RoadNavigator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OilEnvManager : MonoBehaviour
{
    public static OilEnvManager instance;
    public Text levelText;

    public RCC_CarControllerV3[] trucks, oilTrucks;

    public OilLevel[] level;

    public GameObject instructionPanel, levelFailedPanel, levelCompletePanel, loadingPanel;
    public int currentLevel, currentTruck;


    private void Awake()
    {
        instance = this;
        foreach(OilLevel i in level)
        {
            i.gameObject.SetActive(false);
        }
    }


    private void Start()
    {
        //Getting Level Information and setting the level setup for the Environment
        if (PlayerPrefs.HasKey(GameConstants.CURRENT_SELECTED_LEVEL))
        {
            currentLevel = PlayerPrefs.GetInt(GameConstants.CURRENT_SELECTED_LEVEL);

        }
        else
        {
            currentLevel = 0;
        }
        //levelText.text = (currentLevel + 1).ToString();


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
        RCC.SpawnRCC(trucks[currentTruck], level[currentLevel].startPoint.position, level[currentLevel].startPoint.rotation, true, true, false);

    }
}



