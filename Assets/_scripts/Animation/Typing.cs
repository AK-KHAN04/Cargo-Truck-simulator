using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Typing : MonoBehaviour
{
    public Text textUI; // Reference to your Text UI component
    public float textSpeed = 0.1f; // Speed at which characters are displayed
    public float wordDelay = 1.0f; // Delay between words

    private string originalText;
    private string displayedText;

    private void Start()
    {
        originalText = textUI.text;
        textUI.text = ""; // Clear the text initially
        StartCoroutine(ShowTextWithTypewriter());
    }

    private IEnumerator ShowTextWithTypewriter()
    {
        string[] words = originalText.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            // Add a space if it's not the first word
            if (i > 0)
            {
                displayedText += " ";
            }

            string word = words[i];

            for (int j = 0; j < word.Length; j++)
            {
                displayedText += word[j];
                textUI.text = displayedText;
                yield return new WaitForSeconds(textSpeed);
            }

            // Delay between words
            yield return new WaitForSeconds(wordDelay);
        }
    }
}
