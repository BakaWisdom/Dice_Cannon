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

        if (randomValue < (threshhold = threshhold + hardStopChance))
        {
            //hard stop object
        }
        else if (randomValue < (threshhold = threshhold + slowChance))
        {
            //slow object
        }
        else if (randomValue < (threshhold = threshhold + boostChance))
        {
            //boost object
        }
        else if (randomValue < (threshhold = threshhold + vBoostChance))
        {
            //vertical boost object
        }
        else if (randomValue < (threshhold = threshhold + hBoostChance))
        {
            //horizontal boost object
        }
        else
        {
            //mimic object default
        }

        return output;
    }
}
