using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPrefab : MonoBehaviour
{
    public float speed = 10.0f; //TODO needs to be based on die velocity
    private Rigidbody2D rigBod;
    private BoxCollider2D boxyCollider;
    private Vector2 screenBounds;
    private float xStart; //TODO set this to constant when good speed found.
    public float yStart;

    // Start is called before the first frame update
    void Start()
    {
        boxyCollider = GetComponent<BoxCollider2D>();
        rigBod = GetComponent<Rigidbody2D>();
        rigBod.velocity = new Vector2(-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        xStart = screenBounds.x * -2;

        transform.position = new Vector3(xStart, yStart);
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
