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
    
    void Start(){
        pointFormats.Add(TimerFormats.Whole, "0");
        pointFormats.Add(TimerFormats.TenthDecimal, "0.0");
        pointFormats.Add(TimerFormats.HundrethsDecimal, "0.00");
    }

    void Update(){
        SetPointsText();
    }

    private void SetPointsText(){
        pointsText.text = hasFormat ? ("Tables:" + tableCount.ToString(pointFormats[format])) : tableCount.ToString();
    }

    public void AddPoints(){
        tableCount--;
    }
}

public enum PointsFormats{
    Whole,
    TenthDecimal,
    HundrethsDecimal

}
