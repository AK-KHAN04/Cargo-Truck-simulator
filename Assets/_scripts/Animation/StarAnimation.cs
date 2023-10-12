using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class StarAnimation : MonoBehaviour
{
    public Image img;
    public float animationDuration = 2.0f;
    public float scaleAnimationDuration = 0.5f;


    private float elapsedTime = 0f;

    public void OnEnable()
    {
        StartCoroutine(nameof(AnimateOpacity));
    }


    public IEnumerator AnimateOpacity()
    {
        while (elapsedTime < animationDuration)
        {
            float t = elapsedTime / animationDuration;
            img.fillAmount = t;

            elapsedTime += Time.deltaTime;
            if (elapsedTime >= animationDuration)
            {
                StartCoroutine(nameof(ScaleUpanimation));
                break;
                
            }
            yield return null;
        }
    }

    public IEnumerator ScaleUpanimation()
    {
        elapsedTime = 0f;
        while (elapsedTime < scaleAnimationDuration)
        {
            float t = elapsedTime / scaleAnimationDuration;
            img.rectTransform.localScale = Vector3.Lerp(Vector3.one, new Vector3(1.5f, 1.5f, 1.5f), t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

}



