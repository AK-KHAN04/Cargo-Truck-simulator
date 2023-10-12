using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimator : MonoBehaviour
{
    public Button myButton;
    public float animationDuration = 1.0f;
    public Vector3 targetScale = new Vector3(1.1f, 1.1f, 1.1f);


    private Vector3 initialScale;
    private float elapsedTime = 0f;

    private bool isScale=true;


    private void OnEnable()
    {
        
        // Store the initial scale and color of the button
        initialScale = new Vector3(1, 1, 1);
      


        // Start the button animation loop
        isScale = true;
        StartCoroutine(AnimationLoop());
    }

   


    private IEnumerator AnimationLoop()
    {
        while (true)
        {
            yield return StartCoroutine(AnimateButton());

        }
    }

    private IEnumerator AnimateButton()
    {
        if (isScale)
        {
            elapsedTime = 0f;
            // Scale up animation
            while (elapsedTime < animationDuration)
            {

                float progress = elapsedTime / (animationDuration);
                myButton.transform.localScale = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(1, 1, 1), progress);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            isScale = false;
        }

        elapsedTime = 0f;

        // Scale up animation
        while (elapsedTime < animationDuration )
        {
            float progress = elapsedTime / (animationDuration );
            myButton.transform.localScale = Vector3.Lerp(initialScale, targetScale, progress);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the button reaches the target scale and color before scaling it down
        myButton.transform.localScale = targetScale;

        // Scale down animation
        elapsedTime = 0f;
        while (elapsedTime < animationDuration )
        {
            float progress = elapsedTime / (animationDuration );
            myButton.transform.localScale = Vector3.Lerp(targetScale, initialScale, progress);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the button ends up at its initial scale and color
        myButton.transform.localScale = initialScale;
    }
}
