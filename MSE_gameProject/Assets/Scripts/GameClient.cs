using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class GameClient : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputfeild;
    private static GameClient instance;
    public int turnindex = 0;
    private static string updatePlayerInfoURL = "http://localhost:8080/move/update/player";
    private static string fetchPlayerInfoURL = "http://localhost:8080/move/info/player";
    private static string fetchPlayerTurnInfoURL = "http://localhost:8080/current/player-turn-info";
    private static string setPlayerTurnInfoURL = "http://localhost:8080/current/player-turn-set";
    private void Awake()
    {
        //init singleton
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    
    // return client instance
    public static GameClient GetInstance()
    {
        return instance;
    }

    //send player's action data
    public IEnumerator ESendData(int playerType,string action ,int x1, int y1, int x2, int y2)
    {
        PlayerForm form = new PlayerForm(playerType, action, x1, y1, x2, y2);
        string jsonData = JsonUtility.ToJson(form);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(updatePlayerInfoURL, jsonData))
        {
            webRequest.uploadHandler.Dispose();
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData);
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
                    Debug.Log("data sent successfully!");
                    Debug.Log("ESend: Wait finishing update");
                    GameManager.GetInstance().SetPlayerState(PlayerState.WAITING);
                    // wait update end
                    GameManager.GetInstance().WaitUpdateFinish();
                    break;
            }
            webRequest.Dispose();
        }
    }
    // get data
    public IEnumerator EFetchPosition(int playerNum)
    {
        int temp = playerNum == 1 ? 2 : 1;
        string url = fetchPlayerInfoURL + "?playerNum=" + temp;
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
                Debug.Log(data);
                Player form = JsonUtility.FromJson<Player>(data);
                GameManager.GetInstance().setFetchedData(form.getPosX(), form.getPosY());
                break;
        }
    }
    //state == waiting
    public IEnumerator EGetTurn(int playerNum)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(fetchPlayerTurnInfoURL);
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
                Debug.Log("get turn successfully!");
                string data = webRequest.downloadHandler.text;
                Debug.Log(data);
                TurnForm form = JsonUtility.FromJson<TurnForm>(data);
                int temp = 0;
                if (form.getTurn().CompareTo("player1") == 0) temp = 1;
                else temp = 2;
                //턴이 바뀜
                if (temp != playerNum) {
                    Debug.Log("EGetTurn: the other finishes update");
                    GameManager.GetInstance().SetPlayerState(PlayerState.OTHERTURN);
                    GameManager.GetInstance().TurnChange();
                    GameManager.GetInstance().GetData();
                }
                break;
        }
    }

    //after update finish
    public IEnumerator ESetTurn(int playerNum)
    {
        Debug.Log("ESetTurn: Set My turn");
        //업데이트 후 내 턴으로 변경
        string turn = playerNum == 1 ? "player1" : "player2";
        TurnForm form = new TurnForm(turn);
        string jsonData = JsonUtility.ToJson(form);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(setPlayerTurnInfoURL, jsonData))
        {
            webRequest.uploadHandler.Dispose();
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData);
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
                    Debug.Log("set turn successfully!");
                    GameManager.GetInstance().SetPlayerState(PlayerState.MYTURN);
                    GameManager.GetInstance().TurnChange();
                    break;
            }
            webRequest.Dispose();
        }
    }
    public void LoadScene(string name)
    {
        turnindex = int.Parse(inputfeild.text);
        Debug.Log(this.GetInstanceID());
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }
}

public class MoveForm {
    public int x;
    public int y;
}

