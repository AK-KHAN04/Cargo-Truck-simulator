using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public Slider SFXSlider;
    public Slider musicSlider;
    [SerializeField] private GameObject steering, tilt, arrows, steeringActive, tiltActive, arrowsActive;

    private void Start()
    {
        Debug.Log(PlayerPrefs.GetFloat(GameConstants.SFX_SPEED));
        SetVolumeToPlayerPrefs();
        SetControls();
    }

    public void SetControls()
    {
        if (PlayerPrefs.HasKey(GameConstants.CONTROL_SELECTION))
        {
            if (PlayerPrefs.GetInt(GameConstants.CONTROL_SELECTION) == 0)
            {
                TiltActive();
            }
            else if (PlayerPrefs.GetInt(GameConstants.CONTROL_SELECTION) == 1)
            {
                ArrowsActive();
            }
            else
            {
                SteeringActive();
            }
        }
        else
        {
            ArrowsActive();
        }
    }

    public void SteeringActive()
    {
        steeringActive.SetActive(true);
        arrowsActive.SetActive(false);
        tiltActive.SetActive(false);

        steering.SetActive(false);
        arrows.SetActive(true);
        tilt.SetActive(true);

        RCC.SetMobileController(RCC_Settings.MobileController.SteeringWheel);
        PlayerPrefs.SetInt(GameConstants.CONTROL_SELECTION, 2);
    }

    public void ArrowsActive()
    {
        steeringActive.SetActive(false);
        arrowsActive.SetActive(true);
        tiltActive.SetActive(false);

        steering.SetActive(true);
        arrows.SetActive(false);
        tilt.SetActive(true);
        RCC.SetMobileController(RCC_Settings.MobileController.TouchScreen);
        PlayerPrefs.SetInt(GameConstants.CONTROL_SELECTION, 1);

    }

    public void TiltActive()
    {
        steeringActive.SetActive(false);
        arrowsActive.SetActive(false);
        tiltActive.SetActive(true);

        steering.SetActive(true);
        arrows.SetActive(true);
        tilt.SetActive(false);
        RCC.SetMobileController(RCC_Settings.MobileController.Gyro);
        PlayerPrefs.SetInt(GameConstants.CONTROL_SELECTION, 0);
    }



    public void SetVolumeToPlayerPrefs()
    {
        SFXSlider.value = PlayerPrefs.GetFloat(GameConstants.SFX_SPEED);
        musicSlider.value = PlayerPrefs.GetFloat(GameConstants.MUSIC_SPEED);
    }

    public void MusicValueChanged()
    {
        PlayerPrefs.SetFloat(GameConstants.MUSIC_SPEED, musicSlider.value);
        AudioManager.instance.soundSourceBG.volume = musicSlider.value;
    }

    public void SFXvalueChanged()
    {
        PlayerPrefs.SetFloat(GameConstants.SFX_SPEED, SFXSlider.value);
        AudioManager.instance.soundSource.volume = SFXSlider.value;
    }
}
