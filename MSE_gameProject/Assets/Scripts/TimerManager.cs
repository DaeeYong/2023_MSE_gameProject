using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public Slider sliderTime;


    public float leftTime;
    public bool inTurn;

    private void Start() {
        inTurn = true;
    }

    private void FixedUpdate() {
        if(inTurn)
        {
            leftTime -= 1 * Time.deltaTime;
            sliderTime.value = leftTime;

            if(leftTime <= 0)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().TurnChange();
            }
        }
    }
}