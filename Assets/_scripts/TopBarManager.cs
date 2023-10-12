using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBarManager : MonoBehaviour
{
    public static TopBarManager instance;
    public GameObject MainMenuPanel, LevelSelectionPanel, ExitPanel, SettingPanel, ShopPanel, TruckSelectionPanel,LoadingPanel, ModeSelectionPanel;
    

    private void Awake()
    {
        instance = this;
    }
    public void BackBtnClick()
    {
        if(ModeSelectionPanel.activeInHierarchy)
        {
            ModeSelectionPanel.SetActive(false);
            MainMenuPanel.SetActive(true);
        }
        else if(LevelSelectionPanel.activeInHierarchy)
        {
            LevelSelectionPanel.SetActive(false);
            ModeSelectionPanel.SetActive(true);
        }
        else if(MainMenuPanel.activeInHierarchy)
        {
            MainMenuPanel.SetActive(false); 
            ExitPanel.SetActive(true);
        }
        else if (TruckSelectionPanel.activeInHierarchy)
        {
            TruckSelectionPanel.SetActive(false);
            LevelSelectionPanel.SetActive(true);
        }
    }


    public void NoExitBtnClick()
    {
        MainMenuPanel.SetActive(true);
        ExitPanel.SetActive(false);
    }

    public void YesExitBtnClcik()
    {
        Application.Quit();
    }

    public void SettingBtnClick()
    {
        SettingPanel.SetActive(true);
    }

    public void ExitSettingBtnClick()
    {
        SettingPanel.SetActive(false);
    }

    public void ShopBtnClick()
    {
        ShopPanel.SetActive(true);
    }

    public void ExitShopBtnClick()
    {
        ShopPanel.SetActive(false);
    }
}
