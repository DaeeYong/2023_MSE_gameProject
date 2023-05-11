using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class TestData : MonoBehaviour
{
    private string register_url = "http://localhost:8080/add";
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

        // we need to encode json to raw bytes because UnityWebRequest cannot 
        // handle well JSON with POST (PUT should work fine). 
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(memberJSON);
        webRequest.uploadHandler = new UploadHandlerRaw(jsonToSend);
            
        // set the request header: tell the server that we are sending JSON
        webRequest.SetRequestHeader("Content-Type", "application/json");

        // Make the request and wait for it to complete.
        // Before this you might show a label like "Sending..." to the user.
        yield return webRequest.SendWebRequest();

        // check the result. This code runs after the webrequest completes or an error occurs.
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

        //webRequest.Dispose();
    }
}
