using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuManager : MonoBehaviour
{
   public void PlayBtnClick()
    {
        TopBarManager.instance.ModeSelectionPanel.SetActive(true);
        TopBarManager.instance.MainMenuPanel.SetActive(false);
    }

    public void PrivacyPolicyBtnClick()
    {
        Application.OpenURL("https://nightslab.blogspot.com/2023/01/privacy-policy-for-nights-labs.html");

    }

    public void ShareBtnClick()
    {
        Application.OpenURL("https://play.google.com/store/search?q=pub%3A%20Nightslabs&c=apps");
    }

    public void MoreGamesBtnClick()
    {
        Application.OpenURL("https://play.google.com/store/search?q=pub%3A%20Nightslabs&c=apps");
    }

    public void RateUsBtnClick()
    {
        Application.OpenURL("https://play.google.com/store/search?q=pub%3A%20Nightslabs&c=apps");
    }

    public void SettingBtnClick()
    {
        TopBarManager.instance.SettingPanel.SetActive(true);
    }
}
