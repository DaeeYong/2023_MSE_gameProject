using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WaitingRoomManager : MonoBehaviour
{
    public TextMeshProUGUI errortext;
    public void GameStart()
    {
        StartCoroutine(GameClient.GetInstance().StartGame(errortext));
    }
}
