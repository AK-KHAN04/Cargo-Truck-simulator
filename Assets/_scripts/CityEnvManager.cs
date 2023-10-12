using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using InsaneSystems.RoadNavigator;
public class CityEnvManager : MonoBehaviour
{
    public static CityEnvManager instance;

    public RCC_CarControllerV3 activeVechile;
    public GameObject instructionPanel, levelFailedPanel, levelCompletePanel, loadingPanel;
    public int currentLevel, currentTruck;

    public Text levelText;


    public Transform[] startPositions;
    public Transform[] endPositions;
    public Transform[] containerPositions;
    public RCC_CarControllerV3[] trucks;
    public RCC_CarControllerV3[] containers;
    public RCC_CarControllerV3[] woods;
    public RCC_CarControllerV3[] oil;
    public RCC_CarControllerV3[] overWeight;
    public RCC_CarControllerV3[] overWeightLogs;
    public RCC_CarControllerV3[] woodDrums;
    public RCC_CarControllerV3[] topNew;
    public RCC_CarControllerV3[] overWeightSacks;


    public Text instructionText;

    //Tutorials Elements
    public GameObject allTutsObjects;
    public GameObject engine, left, right, race, brake;
    public DOTweenAnimation raceT, brakeT, leftT, rightT;
   
   


    Navigator navigator;

    //SKyBox Materials
    public Material sky, sky2, sky3;


    private static bool tutorialEngine = false, racePressed = false, leftPressed = false, rightPressed = false, brakePressed = false;

    private void Awake()
    {
        instance = this;
       
    }
    private void Start()
    {
        RenderSettings.skybox = sky;
        navigator = FindObjectOfType<Navigator>();


        //Getting Level Information and setting the level setup for the Environment
        if (PlayerPrefs.HasKey(GameConstants.CURRENT_SELECTED_LEVEL))
        {
            currentLevel = PlayerPrefs.GetInt(GameConstants.CURRENT_SELECTED_LEVEL);

        }
        else
        {
            currentLevel = 0;
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
        RCC.SpawnRCC(trucks[currentTruck], startPositions[currentLevel].transform.position, startPositions[currentLevel].transform.rotation, true, true, false);
        ActivateStartPosition();


        Debug.Log("Current truck selected is " + currentTruck);
        activeVechile = trucks[currentTruck].GetComponent<RCC_CarControllerV3>();
        Invoke(nameof(SetTheActiveVechile), 1f);


        // setting the Environments for the the Levels
        if (currentLevel == 0)
        {
            StartTutorial();
            tutorialEngine = true;
            racePressed = true;
            rightPressed = true;
            leftPressed = true;
            brakePressed = true;
            endPositions[currentLevel].gameObject.SetActive(true); // no gps for Level 1 as it is away from the road and the level Finish is clearly visible
        }
        else if (currentLevel == 1)
        {
            ActivateEndPosition();
        }
        else if (currentLevel == 2)
        {
            ShowInstructionPanel("Attach the container", true);
        }
        else
        {
            ShowInstructionPanel("Attach the trailer", true);
        }
    }


    public void SetTheActiveVechile()
    {
        activeVechile = RCC_Camera.instance.cameraTarget.playerVehicle;
        Debug.Log(activeVechile.name);
    }


    #region Tutorial

    public void StartTutorial()
    {

        allTutsObjects.SetActive(false);
        engine.SetActive(false);
        ShowInstructionPanel("This is a tutorial to this game", false);
        Invoke(nameof(StartTheEngine), 4f);
    }

    public void StartTheEngine()
    {

        engine.SetActive(true);
        ShowInstructionPanel("Press the Engine Button to start Vechille", false);
    }

    public void EngineStarts()
    {
        if (tutorialEngine)
        {
            tutorialEngine = false;
            engine.SetActive(false);
            Debug.Log("Engine starts");
            allTutsObjects.SetActive(true);
            race.SetActive(false);
            brake.SetActive(false);
            right.SetActive(false);
            left.SetActive(false);

            AcceleratorTutorial();
        }


    }

    public void AcceleratorTutorial()
    {
        race.SetActive(true);
        raceT.DOPlay();
        ShowInstructionPanel("press The accelerator to Move", false);
    }

    public void RacePressed()
    {
        if (racePressed)
        {
            racePressed = false;
            raceT.DOKill();
            race.GetComponentInChildren<Button>().gameObject.transform.localScale = Vector3.one;
            DisableInstructionPanel();
            Invoke(nameof(MoveLeft), 3f);
        }
    }

    public void MoveLeft()
    {
        Time.timeScale = 0;
        left.SetActive(true);
        leftT.DOPlay();
        ShowInstructionPanel("Press the Left Button to Move Left", false);
    }

    public void LeftPressed()
    {
        if (leftPressed)
        {
            Time.timeScale = 1;
            leftPressed = false;
            leftT.DOKill();
            left.GetComponentInChildren<Button>().gameObject.transform.localScale = Vector3.one;
            DisableInstructionPanel();
            Invoke(nameof(MoveRight), 2f);
        }
    }

    public void MoveRight()
    {
        Time.timeScale = 0;
        right.SetActive(true);
        rightT.DOPlay();

        ShowInstructionPanel("Press the Right Button to Move right", false);
    }
    public void RightPressed()
    {
        if (rightPressed)
        {
            Time.timeScale = 1;
            rightPressed = false;
            rightT.DOKill();
            right.GetComponentInChildren<Button>().gameObject.transform.localScale = Vector3.one;
            DisableInstructionPanel();
            Invoke(nameof(Brake), 2f);
        }
    }

    public void Brake()
    {
        Time.timeScale = 0;
        brake.SetActive(true);
        brakeT.DOPlay();
        ShowInstructionPanel("Press the brake To reduce Speed", false);
    }

    public void BrakePressed()
    {
        if (brakePressed)
        {
            Time.timeScale = 1;
            brakePressed = false;
            brakeT.DOKill();
            brake.GetComponentInChildren<Button>().gameObject.transform.localScale = Vector3.one;
            DisableInstructionPanel();
            ShowInstructionPanel("Move Truck TO End Point", true);
        }
    }


    #endregion



    #region Panel actiavtion and deactivation

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

    public void ShowLoadingPanel(bool SelfDeactivate)
    {
        loadingPanel.SetActive(true);
        if (SelfDeactivate)
        {
            Invoke(nameof(DisableLoadingPanel), 2f);
        }
    }

    public void DisableLoadingPanel()
    {
        loadingPanel.SetActive(false);
    }

    public void LevelComplete()
    {
        StartCoroutine(nameof(LevelCompleteCoroutine));
    }

    public IEnumerator LevelCompleteCoroutine()
    {
        yield return new WaitForSeconds(2f);

        levelCompletePanel.SetActive(true);
    }

    #endregion



    #region Level Finish 

    public void NextLevel()
    {
        //setting disActive Previuos level positons and paths 
        DeActivateEndPosition();
        if (currentLevel == 9)
        {
            ShowInstructionPanel("You finished the City Mode", true);
        }
        else
        {

            currentLevel++;
            PlayerPrefs.SetInt(GameConstants.CURRENT_SELECTED_LEVEL, currentLevel);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    #endregion


    #region ChangeTrucks


    public void ChangeTrucks()
    {
        switch (currentLevel)
        {
            case 2:
                ChangingTruck(containers[currentTruck]);
                break;
            case 3:
                ChangingTruck(woods[currentTruck]);
                break;
            case 4:
                ChangingTruck(oil[currentTruck]);
                break;
            case 5:
                ChangingTruck(overWeight[currentTruck]);
                break;
            case 6:
                ChangingTruck(overWeightLogs[currentTruck]);
                break;
            case 7:
                ChangingTruck(woodDrums[currentTruck]);
                break;
            case 8:
                ChangingTruck(topNew[currentTruck]);
                break;
            case 9:
                ChangingTruck(overWeightSacks[currentTruck]);
                break;
            case 10:
                Debug.Log("All Levels are completed");
                break;
            default:
                Debug.LogError("Level array is out of bound");
                break;

        }
    }

    public void ChangingTruck(RCC_CarControllerV3 truck)
    {
        // trucks[currentTruck].gameObject.SetActive(false);
        Destroy(FindAnyObjectByType<RCC_CarControllerV3>().gameObject);
        DeActivateStartPosition();
        ShowLoadingPanel(true);
        RCC.SpawnRCC(truck, containerPositions[currentLevel].transform.position,
            containerPositions[currentLevel].transform.rotation, true, true, true);
        ActivateEndPosition();
    }

    #endregion


    #region start and End position Functions

    public void ActivateEndPosition()
    {
        endPositions[currentLevel].gameObject.SetActive(true);
        navigator.SetTargetPoint(endPositions[currentLevel].position);
    }

    public void ActivateStartPosition()
    {
        startPositions[currentLevel].gameObject.SetActive(true);
    }

    public void DeActivateEndPosition()
    {
        endPositions[currentLevel].gameObject.SetActive(false);
    }
    public void DeActivateStartPosition()
    {
        startPositions[currentLevel].gameObject.SetActive(false);
    }

    #endregion
}
