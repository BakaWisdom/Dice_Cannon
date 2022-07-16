using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    public int hardStopChance;
    public int slowChance;
    public int boostChance;
    public int vBoostChance;
    public int hBoostChance;
    public int mimicChance;
    int maxRandomVal;

    public void Start()
    {
        maxRandomVal = hardStopChance + slowChance + boostChance + vBoostChance + hBoostChance + mimicChance;
    }

    public GameObject GetNextObstacle()
    {
        GameObject output = new GameObject();
        int randomValue = Random.Range(0, maxRandomVal);
        int threshhold = 0;

        if (randomValue < (threshhold = calculatePercentileRange(threshhold,hardStopChance)))
        {
            //hard stop object
        }
        else if (randomValue < (threshhold = calculatePercentileRange(threshhold, slowChance)))
        {
            //slow object
        }
        else if (randomValue < (threshhold = calculatePercentileRange(threshhold, boostChance)))
        {
            //boost object
        }
        else if (randomValue < (threshhold = calculatePercentileRange(threshhold, vBoostChance)))
        {
            //vertical boost object
        }
        else if (randomValue < (threshhold = calculatePercentileRange(threshhold, hBoostChance)))
        {
            //horizontal boost object
        }
        else
        {
            //mimic object default
        }

        return output;
    }

    private int calculatePercentileRange(int lastThreshold, int chance)
    {
        return lastThreshold + chance * maxRandomVal / 100;
    }
}
