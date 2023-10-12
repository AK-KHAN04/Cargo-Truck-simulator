using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelFinishPanel : MonoBehaviour
{
    public Text levelText;
    public Text timeText;
    public Text fuelText;
    public Text rewardText;

    public float animationTime = 2f; // The time it takes to animate the values.
    public int maxLevel = 10;
    public int maxTime = 50;
    public int maxFuel = 100;
    public int maxReward = 100;

    /*
    private float currentTime = 0f;
    private int currentLevel = 0;
    private int currentFuel = 0;
    private int currentReward = 0;  */

    private IEnumerator currentAnimation;

    private void Start()
    {
        ShowPanel();
    }
    public void ShowPanel()
    {
        // Start a coroutine for each animation.
        currentAnimation = AnimateText(levelText, maxLevel);
        StartCoroutine(currentAnimation);
    }

    private IEnumerator AnimateText(Text text, int maxValue)
    {
        float elapsedTime = 0f;
        int startValue = 0;

        while (elapsedTime < animationTime)
        {
            int animatedValue = Mathf.FloorToInt(Mathf.Lerp(startValue, maxValue, elapsedTime / animationTime));
            text.text =  animatedValue.ToString();
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the text displays the final value.
        text.text =  maxValue.ToString();

        // Wait for a short delay before starting the next animation.
        yield return new WaitForSeconds(0.5f);

        // Start the next animation.
        if (text == levelText)
        {
            currentAnimation = AnimateText(fuelText, maxTime);
            StartCoroutine(currentAnimation);
        }
        else if (text == timeText)
        {
            currentAnimation = AnimateText(rewardText, maxFuel);
            StartCoroutine(currentAnimation);
        }
        else if (text == fuelText)
        {
            currentAnimation = AnimateText(timeText, maxReward);
            StartCoroutine(currentAnimation);
        }
        else
        {
            // All animations are complete.
            currentAnimation = null;
        }
    }
}


