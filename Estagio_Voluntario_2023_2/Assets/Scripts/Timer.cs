using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header ("Component")]
    public TextMeshProUGUI timerText;

    [Header ("Timer Settings")]
    public float curTime;
    public bool countDown;  

    [Header ("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    [Header ("Format Settings")]
    public bool hasFormat;
    public TimerFormats format;
    private Dictionary<TimerFormats, string> timeFormats = new Dictionary<TimerFormats, string>();

    private bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        timeFormats.Add(TimerFormats.Whole, "0");
        timeFormats.Add(TimerFormats.TenthDecimal, "0.0");
        timeFormats.Add(TimerFormats.HundrethsDecimal, "0.00");
    }

    // Update is called once per frame
    void Update()
    {
        curTime = countDown ? curTime -= Time.deltaTime : curTime += Time.deltaTime;
        
        if(hasLimit && ((countDown && curTime <= timerLimit) || (!countDown && curTime >= timerLimit))){
            curTime = timerLimit;
            gameOver = true;
            SetTimerText();
            timerText.color = Color.red;
            enabled = false;
        }
        
        SetTimerText();
    }

    private void SetTimerText(){
        timerText.text = hasFormat ? curTime.ToString(timeFormats[format]) : curTime.ToString();
    }

    public bool GetGameOver(){
        return gameOver;
    }
}

public enum TimerFormats{
    Whole,
    TenthDecimal,
    HundrethsDecimal

}
