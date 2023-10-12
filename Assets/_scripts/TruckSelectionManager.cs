using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TruckSelectionManager : MonoBehaviour
{
    public static TruckSelectionManager instance;

    [SerializeField]
    private GameObject  buybtn, unlockAll, playBtn,notEnoughCash, truckPriceObject;
    [SerializeField] private Text coinsText;
    [SerializeField]
    private Button nextBtn, PrevBtn;


    public GameObject[] trucks;
    //public bool[] trucksUnlocked;
    public GameObject locks;
    public int CurrentTruck;


    // Car Specification input
    public Image acceleration, damage, brakes, handle;
    public Text truckName, truckPriceText;
    private void Awake()
    {
        instance = this;

    }

    private void Start()
    {
        //Activating the last active truck saved in playerprefs
        if (PlayerPrefs.HasKey(GameConstants.TRUCK_SELECTED))
        {
            CurrentTruck = PlayerPrefs.GetInt(GameConstants.TRUCK_SELECTED);
            trucks[CurrentTruck].SetActive(true);

            /*
            for(int i=0; i == CurrentTruck; i++)
            {
                trucksUnlocked[i] = true;
            }*/
            if(GetTruckUnlockedStatus(CurrentTruck) == false)
            {
                buybtn.SetActive(true);
                truckPriceObject.SetActive(true); 
            }

            if (CurrentTruck == 0)
            {
                PrevBtn.interactable = false;
            }
            else if (CurrentTruck >= trucks.Length)
            {
                nextBtn.interactable = false;
            }
        }
        else
        {
            CurrentTruck = 0;
            trucks[0].SetActive(true);
            SetTruckUnlockedStatus(0, true);
            PrevBtn.interactable = false;
        }
    }
    public void PlayBtnClick()
    {
        TopBarManager.instance.LoadingPanel.SetActive(true);
        if(PlayerPrefs.GetInt(GameConstants.MODE_SELECTION) == 0)
        {
            LoadingHandler.instance.SceneToLoad = 3;
        }
        else
        {
            LoadingHandler.instance.SceneToLoad = 2;
        }
        TopBarManager.instance.TruckSelectionPanel.SetActive(false);
        PlayerPrefs.SetInt(GameConstants.TRUCK_SELECTED, CurrentTruck);
    }


    //Next button of truck selecttion
    public void NextBtnClick()
    {
        trucks[CurrentTruck].SetActive(false);
        CurrentTruck++;
        trucks[CurrentTruck].SetActive(true);

        
        if (GetTruckUnlockedStatus(CurrentTruck) == false)
        {
            locks.SetActive(true);
            buybtn.SetActive(true);
            truckPriceObject.SetActive(true);
            playBtn.SetActive(false);

        }
        else
        {
            locks.SetActive(false);
            buybtn.SetActive(false);
            truckPriceObject.SetActive(false);
            playBtn.SetActive(true);

        }

        if (CurrentTruck >= trucks.Length-1)
        {
            nextBtn.interactable = false;
        }

        if (CurrentTruck > 0)
        {
            PrevBtn.interactable = true;
        }
    }


    //Previous button of truuck selection
    public void PrevBtnClick()
    {
        trucks[CurrentTruck].SetActive(false);
        CurrentTruck--;
        trucks[CurrentTruck].SetActive(true);

        if (GetTruckUnlockedStatus(CurrentTruck) == false)
        {
            locks.SetActive(true);
            buybtn.SetActive(true);
            truckPriceObject.SetActive(true);
            playBtn.SetActive(false);
        }
        else
        {
            locks.SetActive(false);
            buybtn.SetActive(false);
            truckPriceObject.SetActive(false);
            playBtn.SetActive(true);

        }

        if (CurrentTruck <= 0)
        {
            PrevBtn.interactable = false;
        }

        if (CurrentTruck < trucks.Length)
        {
            nextBtn.interactable = true;
        }
    }

    public void BuyBtnClick()
    {
        int price = int.Parse(truckPriceText.text);
        int coins = int.Parse(coinsText.text);

        if(price >= coins)
        {
            Debug.Log("Hello workd");
            SetTruckUnlockedStatus(CurrentTruck, true);
            buybtn.SetActive(false);
            truckPriceObject.SetActive(false);
            locks.SetActive(false);
            playBtn.SetActive(true);
        }
        else
        {
            notEnoughCash.SetActive(true);
            Invoke(nameof(NotEnoughCashActivate),2f);
        }
    }


    private void NotEnoughCashActivate()
    {
        notEnoughCash.SetActive(false);
    }

    public  void SetTruckUnlockedStatus(int truckIndex, bool isUnlocked)
    {
        string key = "Truck" + (truckIndex + 1) + "Unlocked";
        PlayerPrefs.SetInt(key, isUnlocked ? 1 : 0);
    }


    public  bool GetTruckUnlockedStatus(int truckIndex)
    {
        string key = "Truck" + (truckIndex + 1) + "Unlocked";
        return PlayerPrefs.GetInt(key, 0) == 1;
    }

    public  void UnlockAllTrucks()
    {
        for (int i = 0; i < 10; i++)
        {
            SetTruckUnlockedStatus(i, true);
            buybtn.SetActive(false);
            truckPriceObject.SetActive(false);
            locks.SetActive(false);
            playBtn.SetActive(true);
        }
    }

    public  bool AreAllTrucksUnlocked()
    {
        for (int i = 0; i < 10; i++)
        {
            if (!GetTruckUnlockedStatus(i))
            {
                return false; // If any truck is not unlocked, return false
            }
        }
        return true; // If all trucks are unlocked, return true
    }




}
