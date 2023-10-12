using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSelectionManager : MonoBehaviour
{
    [SerializeField]
    private GameObject hill, hillActive, city, cityActive;


    private void Start()
    {
        if(PlayerPrefs.HasKey(GameConstants.MODE_SELECTION))
        {
            if(PlayerPrefs.GetInt(GameConstants.MODE_SELECTION) == 0)
            {
                HillEnvSelected();
            }
            else
            {
                CityEnvSelected();
            }
        }
        else
        {
            HillEnvSelected();
        }
    }


    public void HillEnvSelected()
    {
        hill.SetActive(false);
        hillActive.SetActive(true);
        city.SetActive(true);
        cityActive.SetActive(false);
        PlayerPrefs.SetInt(GameConstants.MODE_SELECTION, 0);
        Debug.Log("Hill selectd");
    }
    
    public void CityEnvSelected()
    {
        hill.SetActive(true);
        hillActive.SetActive(false);
        city.SetActive(false);
        cityActive.SetActive(true);
        PlayerPrefs.SetInt(GameConstants.MODE_SELECTION, 1);
        Debug.Log("City selected");
    }


    public void PlayBtnClick()
    {
        TopBarManager.instance.ModeSelectionPanel.SetActive(false);
        TopBarManager.instance.LevelSelectionPanel.SetActive(true);
    }
}
