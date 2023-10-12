using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;



public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    [Header("Panels")]
    public GameObject pausePanel;
    public GameObject levelFailedPanel;
    public GameObject levelCompletePanel;
    public GameObject settingPanel;

    [Header("Trailer Attaching Buttons")]
    public GameObject attachTrailer;
    public GameObject deAttachTrailer;

    [Header("Gears")]
    public GameObject drive;
    public GameObject driveActive;
    public GameObject parking;
    public GameObject parkingActive;
    public GameObject reverse;
    public GameObject ReverseActive;

    [Header("Engine")]
    public GameObject engineOn;
    public GameObject engineOff;

    [Header("Lights and Indicators")]
    public GameObject leftOn;
    public GameObject leftOff;
    public GameObject rightOn;
    public GameObject rightOff;
    public GameObject headOn;
    public GameObject headOff;

    [Header("Sound")]
    public AudioSource horn;
   


    public void Awake()
    {
        instance = this;
    }

    #region Trailer Attacher
    public void AttachTrailer()
    {
        attachTrailer.SetActive(false);
        deAttachTrailer.SetActive(true);
    }

    public void DeAttachTrailer()
    {
        attachTrailer.SetActive(true);
        deAttachTrailer.SetActive(false);
    }
    #endregion


    #region Horn

    public void Horn()
    {

    }
    #endregion


    #region Gears

    public void Drive()
    {
        drive.SetActive(false);
        driveActive.SetActive(true);
        parking.SetActive(true);
        parkingActive.SetActive(false);
        reverse.SetActive(true);
        ReverseActive.SetActive(false);
    }

    public void Parking()
    {
        drive.SetActive(true);
        driveActive.SetActive(false);
        parking.SetActive(false);
        parkingActive.SetActive(true);
        reverse.SetActive(true);
        ReverseActive.SetActive(false);
    }

    public void Reverse()
    {
        drive.SetActive(true);
        driveActive.SetActive(false);
        parking.SetActive(true);
        parkingActive.SetActive(false);
        reverse.SetActive(false);
        ReverseActive.SetActive(true);
    }

    #endregion

    #region  Engine Status


    public void StartEngine()
    {
        engineOff.SetActive(false);
        engineOn.SetActive(true);

    }

    public void OffEngine()
    {
        engineOff.SetActive(true);
        engineOn.SetActive(false);

    }

    #endregion


    #region lights and Indicators

    public void LightsOn()
    {
        headOff.SetActive(true);
        headOn.SetActive(false);
    }

    public void LightsOff()
    {

        headOn.SetActive(true);
        headOff.SetActive(false);
    }

    public void LeftIndicatorOn()
    {
        leftOn.SetActive(false);
        leftOff.SetActive(true);
        rightOn.SetActive(true);
        rightOff.SetActive(false);
    }

    public void LeftIndicatorOff()
    {
        leftOn.SetActive(true);
        leftOff.SetActive(false);
    }

    public void RightIndicatorOn()
    {
        rightOn.SetActive(false);
        rightOff.SetActive(true);
        leftOn.SetActive(true);
        leftOff.SetActive(false);
    }

    public void RightIndicatorOff()
    {
        rightOn.SetActive(true);
        rightOff.SetActive(false);
    }

    #endregion


    #region Buttons functions
    public void PauseBtnClick()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void SettingBtnClick()
    {
        settingPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeBtnClick()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }


    public void HomeBtnClick()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }


    public void RestartBtnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void SettingCrossBtnClick()
    {
        settingPanel.SetActive(false);
        Time.timeScale = 1;
    }


    #endregion


}