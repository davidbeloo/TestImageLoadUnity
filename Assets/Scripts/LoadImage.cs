using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadImage : MonoBehaviour {

    public RawImage imageToDisplay;
    string url = "http://i.stack.imgur.com/Cu4SA.png";

    void Start()
    {
        StartCoroutine(loadSpriteImageFromUrl(url));
    }

    IEnumerator loadSpriteImageFromUrl(string URL)
    {
        // Check internet connection
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            yield return null;
        }

        var www = new WWW(URL);
        Debug.Log("Download image on progress");
        yield return www;

        if (string.IsNullOrEmpty(www.text))
        {
            Debug.Log("Download failed");
        }
        else
        {
            Debug.Log("Download succes");
            Texture2D texture = new Texture2D(1, 1);
            texture.LoadImage(www.bytes);
            texture.Apply();

            imageToDisplay.texture = texture;
        }
    }
}
