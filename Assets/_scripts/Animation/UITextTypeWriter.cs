using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// attach to UI Text component (with the full text already there)

public class UITextTypeWriter : MonoBehaviour 
{
    public	Text txt;
   
   public string story;
   
    private void OnEnable()
    {
        
      
        txt.text = string.Empty;
        StartCoroutine(nameof(PlayText));
    }


IEnumerator PlayText()
{
    foreach (char c in story)
    {
        txt.text += c;
        yield return new WaitForSeconds(0.05f);
    }
}

}