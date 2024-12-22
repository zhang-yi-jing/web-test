using UnityEngine;

public class OpenURL : MonoBehaviour
{
    public string urlToOpen = "https://www.example.com";

    public void OpenExternalURL()
    {
        Application.OpenURL(urlToOpen);
        Debug.Log(1);
    }
}