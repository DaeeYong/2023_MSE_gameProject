using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float leftTime = 30;

    private void FixedUpdate() {
        
        leftTime -= 1 * Time.deltaTime;
        timerText.text = ("Turn Time : " + (int)leftTime).ToString();

        if(leftTime <= 0)
        {
            notifyZeroTime();
            leftTime = 30;
        }
    }

    private void notifyZeroTime()
    {
        GameObject gameManager = GameObject.FindGameObjectWithTag("GameController");
        gameManager.GetComponent<GameManager>().TurnChage();

    }
}
