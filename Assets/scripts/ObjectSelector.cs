using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    public int hardStopChance;
    public GameObject hardStopPrefab;
    public int slowChance;
    public GameObject slowPrefab;
    public int boostChance;
    public GameObject boostPrefab;
    public int vBoostChance;
    public GameObject vBoostPrefab;
    public int hBoostChance;
    public GameObject hboostPrefab;
    public int mimicChance;
    public GameObject mimicPrefab;
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
            output = hardStopPrefab;
        }
        else if (randomValue < (threshhold = threshhold + slowChance))
        {
            output = slowPrefab;
        }
        else if (randomValue < (threshhold = threshhold + boostChance))
        {
            output = boostPrefab;
        }
        else if (randomValue < (threshhold = threshhold + vBoostChance))
        {
            output = vBoostPrefab;
        }
        else if (randomValue < (threshhold = threshhold + hBoostChance))
        {
            output = hboostPrefab;
        }
        else
        {
            output = mimicPrefab;
        }

        return output;
    }
}
