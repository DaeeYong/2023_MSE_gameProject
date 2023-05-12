using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class TestData : MonoBehaviour
{
    private string register_url = "http://localhost:8080/sign-up";
    public TMP_InputField registerName;

    public void Register()
    {
        StartCoroutine(RegisterRequest());
    }

    private string parseInput()
    {
        TestMember m = new TestMember();
        m.name = registerName.text;
        string json = JsonUtility.ToJson(m);
        return json;
    }

    IEnumerator RegisterRequest()
    {
        string memberJSON = parseInput();

        UnityWebRequest webRequest = UnityWebRequest.Post(register_url, memberJSON);

        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(memberJSON);
        webRequest.uploadHandler = new UploadHandlerRaw(jsonToSend);
            
        webRequest.SetRequestHeader("Content-Type", "application/json");

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
                Debug.Log("Member sent successfully!");
                break;
        }
    }
}
