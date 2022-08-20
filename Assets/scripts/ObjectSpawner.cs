using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
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
    int maxRandomVal;
    public float surfaceLoc = 5;
    Vector3 screenBounds;

    private float spawnTime = 1.0f;

    public void Start()
    {
        maxRandomVal = hardStopChance + slowChance + boostChance + vBoostChance + hBoostChance;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        StartCoroutine(ObjectWave());
    }
    private void SpawnObstacle()
    {
        GameObject newObstacle = Instantiate(GetNextObstacle());
        newObstacle.transform.position = new Vector2(screenBounds.x * -2, surfaceLoc - screenBounds.y);
        
        //locations set in generic object script currently.
    }
    IEnumerator ObjectWave()
    {
        //while dice still rolling, while velocity is 0 or still playing
        while(true)
        {
            yield return new WaitForSeconds(spawnTime);

            //TODO make function of dice speed ex. 10 / velocity.x
            spawnTime = Random.Range(0.1f, 1);

            SpawnObstacle();
        }
    }

    private GameObject GetNextObstacle()
    {
        GameObject output;
        int randomValue = Random.Range(0, maxRandomVal);
        int threshhold = 0;

        //return slowPrefab;

        if (randomValue < (threshhold = threshhold + slowChance))
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
        else //hardstop default
        {
            output = hardStopPrefab;
        }

        return output;
    }
}
