using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float leftTime = 30;
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
                leftTime = 30;
            }
        }
    }

    public void makeZerotime()
    {
        leftTime = 0;
    }
}