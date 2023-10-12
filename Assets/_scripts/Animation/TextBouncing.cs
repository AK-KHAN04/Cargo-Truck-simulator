using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBouncing : MonoBehaviour
{
    public Text[] text;
    public float bounceHeight = 20f;
    public float bounceDuration = 0.5f;
    public float delayBetweenBounces = 0.5f;
    public float staggerDelay = 0.2f;

    private void Start()
    {
        StartCoroutine(AnimateWaterFlow());
    }

    IEnumerator AnimateWaterFlow()
    {
        while (true)
        {
            foreach (Text textElement in text)
            {
                StartCoroutine(AnimateText(textElement));
                yield return new WaitForSeconds(staggerDelay);
            }
            yield return new WaitForSeconds(delayBetweenBounces);
        }
    }

    IEnumerator AnimateText(Text textElement)
    {
        Vector3 originalPosition = textElement.transform.position;
        Vector3 targetPosition = originalPosition + new Vector3(0f, bounceHeight, 0f);

        // Bounce animation
        float startTime = Time.time;
        while (Time.time - startTime < bounceDuration)
        {
            float normalizedTime = (Time.time - startTime) / bounceDuration;
            textElement.transform.position = Vector3.Lerp(originalPosition, targetPosition, normalizedTime);
            yield return null;
        }

        // Wait for a delay before returning to original position
        yield return new WaitForSeconds(delayBetweenBounces);

        // Return to original position
        startTime = Time.time;
        while (Time.time - startTime < bounceDuration)
        {
            float normalizedTime = (Time.time - startTime) / bounceDuration;
            textElement.transform.position = Vector3.Lerp(targetPosition, originalPosition, normalizedTime);
            yield return null;
        }
    }

}
