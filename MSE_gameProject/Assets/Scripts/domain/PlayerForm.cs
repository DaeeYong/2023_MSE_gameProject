using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForm
{
    public int playerNumber;
    public string action;
    public int x1; //플레이어 위치
    public int y1; //플레이어 위치
    public int x2; //장애물 설치는 여기까지 사용
    public int y2; //장애물 설치는 여기까지 사용

    public PlayerForm(int playerNumber, string action, int x1, int y1, int x2, int y2)
    {
        this.playerNumber = playerNumber;
        this.action = action;
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
    }

    public string getAction()
    {
        return action;
    }

    public void setAction(string action)
    {
        this.action = action;
    }

    public int getPlayerNumber()
    {
        return playerNumber;
    }

    public void setPlayerNumber(int playerNumber)
    {
        this.playerNumber = playerNumber;
    }

    public int getX1()
    {
        return x1;
    }

    public void setX1(int x1)
    {
        this.x1 = x1;
    }

    public int getY1()
    {
        return y1;
    }

    public void setY1(int y1)
    {
        this.y1 = y1;
    }

    public int getX2()
    {
        return x2;
    }

    public void setX2(int x2)
    {
        this.x2 = x2;
    }

    public int getY2()
    {
        return y2;
    }

    public void setY2(int y2)
    {
        this.y2 = y2;
    }
}
