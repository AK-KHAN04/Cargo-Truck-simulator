using System.Collections;
using UnityEngine;

public class GameObjectAnimator : MonoBehaviour
{
    public GameObject myGameObject;
    public float animationDuration = 1.0f;
    public Vector3 targetScale = new Vector3(1.1f, 1.1f, 1.1f);

    private Vector3 initialScale;
    private float elapsedTime = 0f;

    private bool isScale = true;

    private void Start()
    {
        // Store the initial scale of the GameObject
        myGameObject = this.gameObject;
        initialScale = new Vector3(1,1,1);

        // Start the GameObject animation loop
        isScale = true;
        StartCoroutine(AnimationLoop());
    }

    private IEnumerator AnimationLoop()
    {
        while (true)
        {
            yield return StartCoroutine(AnimateGameObject());
        }
    }

    private IEnumerator AnimateGameObject()
    {
        if (isScale)
        {
            elapsedTime = 0f;
            // Scale up animation
            while (elapsedTime < animationDuration)
            {
                float progress = elapsedTime / animationDuration;
                myGameObject.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, progress);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            isScale = false;
        }

        elapsedTime = 0f;

        // Scale down animation
        while (elapsedTime < animationDuration)
        {
            float progress = elapsedTime / animationDuration;
            myGameObject.transform.localScale = Vector3.Lerp(targetScale, initialScale, progress);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the GameObject ends up at its initial scale
        myGameObject.transform.localScale = initialScale;
    }
}
