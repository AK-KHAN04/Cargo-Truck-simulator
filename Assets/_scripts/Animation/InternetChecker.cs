using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class InternetChecker : MonoBehaviour
{
    public static IEnumerator CheckInternetConnection(System.Action<bool, string> resultCallback)
    {
        UnityWebRequest www = new UnityWebRequest("http://www.google.com");
        www.timeout = 5; // Adjust the timeout as needed
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            string errorMessage = www.error;
            Debug.Log(errorMessage);
            resultCallback(false, errorMessage);
        }
        else
        {
            resultCallback(true, "Connected");
        }
    }







    // Example of how to use the CheckInternetConnection function:
    private void Start()
    {
        StartCoroutine(CheckInternetConnection((isConnected, message) =>
        {
            if (isConnected)
            {
                Debug.Log("Internet is available: " + message);
            }
            else
            {
                Debug.LogError("No internet connection: " + message);
            }
        }));
    }
}
