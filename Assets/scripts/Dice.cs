using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dice : MonoBehaviour
{
    private Vector2 _screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > _screenBounds.x)
        {
            Destroy(this.gameObject);
            //SceneManager.LoadScene(2);
        }
    }
}
