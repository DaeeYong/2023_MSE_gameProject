using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
   public void CreateRoom()
    {
        GameClient.GetInstance().turnindex = 1;
        User user = new User(1, "dongho", "1234");
        StartCoroutine(GameClient.GetInstance().JoinRoom(user, 1));
    }

    public void JoinRoom()
    {
        GameClient.GetInstance().turnindex = 2;
        User user = new User(1, "hodong", "1234");
        StartCoroutine(GameClient.GetInstance().JoinRoom(user, 2));
    }
}
