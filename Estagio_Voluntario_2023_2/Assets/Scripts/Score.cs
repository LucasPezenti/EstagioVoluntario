using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int pointsCount = 0;
    private int minPoints = 10;
    private bool win;

    public int getTotalPoints(){
        return pointsCount;
    }

    public void AddPoints(int num){
        pointsCount += num;
    }

    public void comparePoints(){
        if(pointsCount >= minPoints){
            win = true;
        }
        else{
            win = false;
        }
    }
}
