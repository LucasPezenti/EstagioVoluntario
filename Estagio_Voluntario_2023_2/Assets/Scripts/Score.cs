using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Score : MonoBehaviour
{
    [Header ("Component")]
    public TextMeshProUGUI pointsText;

    [SerializeField] float tableCount;

    [Header ("Format Settings")]
    public bool hasFormat;
    public TimerFormats format;
    private Dictionary<TimerFormats, string> pointFormats = new Dictionary<TimerFormats, string>();

    private bool win;
    
    void Start(){
        pointFormats.Add(TimerFormats.Whole, "0");
        pointFormats.Add(TimerFormats.TenthDecimal, "0.0");
        pointFormats.Add(TimerFormats.HundrethsDecimal, "0.00");
    }

    void Update(){
        SetPointsText();
        if(tableCount <= 0){
            win = true;
        }
    }

    private void SetPointsText(){
        pointsText.text = hasFormat ? ("Mesas:" + tableCount.ToString(pointFormats[format])) : tableCount.ToString();
    }

    public void AddPoints(){
        tableCount--;
    }

    public bool GetWin(){
        return win;
    }
}

public enum PointsFormats{
    Whole,
    TenthDecimal,
    HundrethsDecimal

}
