using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowScript : MonoBehaviour
{
    Image imageComponent;
    // Start is called before the first frame update
    void Start()
    {
        imageComponent = GetComponent<Image>();
        int imageNum = Random.Range(0, 2);
        //TODO need to test filepath
        imageComponent.sprite = (Sprite) Resources.Load("Assets/Art/Obstacles/Slow" + imageNum + ".png");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
