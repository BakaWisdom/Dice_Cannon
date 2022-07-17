using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float speed = 10.0f; //TODO set to dice v speed
    private Rigidbody2D rigBod;
    private BoxCollider2D boxyCollider;
    private Vector2 screenBounds;
    public float xStart; //This should be constant amongst all obstacles y might change a little?

    // Start is called before the first frame update
    void Start()
    {
        boxyCollider = GetComponent<BoxCollider2D>();
        rigBod = GetComponent<Rigidbody2D>();
        rigBod.velocity = new Vector2(-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        transform.position = new Vector3(xStart, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < screenBounds.x - boxyCollider.size.x * 2)
        {
            Destroy(this);
        }
    }
}
