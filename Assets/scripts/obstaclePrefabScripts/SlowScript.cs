using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowScript : MonoBehaviour
{
    Image imageComponent;
    public Sprite[] possibleSprites;
    // Start is called before the first frame update
    void Start()
    {
        imageComponent = GetComponent<Image>();
        int imageNum = Random.Range(0, possibleSprites.Length);

        imageComponent.sprite = possibleSprites[imageNum];


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
