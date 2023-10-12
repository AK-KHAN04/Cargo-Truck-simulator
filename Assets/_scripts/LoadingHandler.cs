using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingHandler : MonoBehaviour
{
    public static LoadingHandler instance;

    [SerializeField] private Image filler;
    [SerializeField] private Text text;
    [SerializeField] public int SceneToLoad;
    private float fillSpeed = 1.0f / 5.0f; // Fill speed to complete the fill in 3 seconds


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        StartCoroutine(LoadSceneAsync());
  
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneToLoad);
        asyncOperation.allowSceneActivation = false;

        float currentFill = 0.0f;

        while (!asyncOperation.isDone)
        {
            // Calculate the new fill amount based on the fill speed and time elapsed.
            currentFill += Time.deltaTime * fillSpeed;
            currentFill = Mathf.Clamp01(currentFill);

            filler.fillAmount = currentFill;
            text.text = (currentFill * 100).ToString("00");

            if (currentFill >= 1)
            {
                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }

  
}
