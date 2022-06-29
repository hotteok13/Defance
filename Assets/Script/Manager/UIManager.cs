using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class UIManager : MonoBehaviour
{
    public GameObject window;
    public RawImage title;

    public void Start()
    {
        StartCoroutine(WebTexture("https://cdn.pixabay.com/photo/2014/04/03/00/41/shield-309126_960_720.png"));
    }
    public void GameStart()
    {
        window.SetActive(false);
        GameManager.instace.state = true;
    }

    IEnumerator WebTexture(string url)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();


        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            title.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        }
    }
}
