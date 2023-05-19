using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class SigninTest : MonoBehaviour
{
    private string signin_url = "http://localhost:8080/sign-in";
    public TMP_InputField signinName;

    public GameObject signinFailPop;
    public GameObject signinSucPop;
    public GameObject GameStartButton;

    public void SignIn()
    {
        StartCoroutine(SignInRequest());
    }

    private string ParseInput()
    {
        MemberData m = new MemberData();
        m.name = signinName.text;
        string json = JsonUtility.ToJson(m);
        return json;
    }

    IEnumerator SignInRequest()
    {
        string memberString = ParseInput();

        UnityWebRequest webRequest = new UnityWebRequest(signin_url, UnityWebRequest.kHttpVerbGET);
        byte[] stringToSend = new System.Text.UTF8Encoding().GetBytes(memberString);
        webRequest.uploadHandler = new UploadHandlerRaw(stringToSend);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
            
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();

        switch (webRequest.result)
        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
                Debug.LogError("Error: " + webRequest.error);
                webRequest.Dispose();
                break;
            case UnityWebRequest.Result.ProtocolError:
                Debug.LogError("HTTP Error: " + webRequest.error);
                webRequest.Dispose();
                break;
            case UnityWebRequest.Result.Success:
                // everything is ok.
                Debug.Log("Data sent successfully!");
                ValidData validdata = JsonUtility.FromJson<ValidData>(webRequest.downloadHandler.text);
                if(validdata.valid) {
                    signinSucPop.SetActive(true);
                    TextMeshProUGUI name = signinSucPop.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                    name.text = "Welcome!\n";
                    name.text += signinName.text;
                    GameStartButton.SetActive(true);
                }
                else {
                    signinFailPop.SetActive(true);
                }
                webRequest.downloadHandler.Dispose();
                webRequest.Dispose();
                break;
        }
    }
}
