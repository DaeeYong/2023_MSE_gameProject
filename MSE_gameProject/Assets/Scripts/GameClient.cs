using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameClient : MonoBehaviour
{
    private static GameClient instance;
    private static string updatePositionP1 = "http://localhost:8080/location/update/player1";
    private static string updatePositionP2 = "http://localhost:8080/location/update/player2";
    private static string fetchPositionP1 = "http://localhost:8080/location/current/player1";
    private static string fetchPositionP2 = "http://localhost:8080/location/current/player2";
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else instance = this;
    }

    public GameClient GetInstance()
    {
        return instance;
    }

    public void SendPosition(int playerType, int x, int y)
    {
        MoveForm form = new MoveForm();
        form.x = x;
        form.y = y;
        string jsonData = JsonUtility.ToJson(form);
        if (playerType == 1) {
            StartCoroutine(ESendPosition(updatePositionP1,jsonData));
        }
        else
        {
            StartCoroutine(ESendPosition(updatePositionP2, jsonData));
        }
    }

    public Vector2 FetchPostion(int playerType)
    {
        Vector2 res = Vector2.zero;
        if (playerType == 2)
        {
            StartCoroutine(EFetchPosition(fetchPositionP1, res));
        }
        else
        {
            StartCoroutine(EFetchPosition(fetchPositionP2, res));
        }
        Debug.Log("Fetch Positon" + res.x + ":" + res.y);
        return res;
    }
    IEnumerator ESendPosition(string url, string jsonData)
    {   

        UnityWebRequest webRequest = UnityWebRequest.Post(url,jsonData);
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData);
        webRequest.uploadHandler = new UploadHandlerRaw(jsonToSend);
        webRequest.SetRequestHeader("Content-Type", "apllication/json");
        yield return webRequest.SendWebRequest();

        switch (webRequest.result)
        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
                Debug.LogError("Error: " + webRequest.error);
                break;
            case UnityWebRequest.Result.ProtocolError:
                Debug.LogError("HTTP Error: " + webRequest.error);
                break;
            case UnityWebRequest.Result.Success:
                // everything is ok.
                Debug.Log("data sent successfully!");
                break;
        }
    }

    IEnumerator EFetchPosition(string url, Vector2 res)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        webRequest.SetRequestHeader("Accept", "application/json");
        yield return webRequest.SendWebRequest();

        switch (webRequest.result)
        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
                Debug.LogError("Error: " + webRequest.error);
                break;
            case UnityWebRequest.Result.ProtocolError:
                Debug.LogError("HTTP Error: " + webRequest.error);
                break;
            case UnityWebRequest.Result.Success:
                // everything is ok.
                Debug.Log("data get successfully!");
                string data = webRequest.downloadHandler.text;
                MoveForm form = JsonUtility.FromJson<MoveForm>(data);
                res = new Vector2(form.x, form.y);
                break;
        }
    }
}

public class MoveForm {
    public int x;
    public int y;
}

