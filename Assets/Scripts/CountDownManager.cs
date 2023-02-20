using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountDownManager : MonoBehaviour
{
    public DateTime EndTime;

    public int TimeGiven = 180;

    public Text CountDownShowText;

    public bool isCountDownFinish;

    /// <summary>
    /// µ¹¼ÆÊ±½áÊø
    /// </summary>
    public event Action CountDownEndEvent;

    public void StartCountDown()
    { 
        EndTime = DateTime.Now.AddSeconds(TimeGiven);
    }

    // Update is called once per frame
    void Update()
    {
        CheckTimeIsOut();

        if (!GameManager.instance.isGameOver)
        {
            CountDownShowText.text = (EndTime - DateTime.Now).ToString("mm':'ss");
        }
    }

    private void CheckTimeIsOut()
    {
        if(GameManager.instance.isGameOver) return;

        if (DateTime.Now > EndTime)
        {
            isCountDownFinish = true;
            CountDownEndEvent?.Invoke();            
        }
    }

}
