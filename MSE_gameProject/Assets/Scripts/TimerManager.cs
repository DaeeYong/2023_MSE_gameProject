using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float leftTime = 30;
    public bool inTurn;

    private void Start() {
        inTurn = true;
    }

    private void FixedUpdate() {
        if(inTurn)
        {
            leftTime -= 1 * Time.deltaTime;
            timerText.text = ("Turn Time : " + (int)leftTime).ToString();

            if(leftTime <= 0)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().TurnChange();
            }
        }
    }
}