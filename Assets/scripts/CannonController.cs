using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CannonController : MonoBehaviour
{
    public GameObject DicePrefab;
    public Transform firePoint;
    public float Speed;

    private bool isFiring = false;
    private Camera _cam;
    private float _maxDegree = 85;
    private float _minDegree = 5;

    private float radIncline;

    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Get angle for cannon incline
        Vector2 angleVector = _cam.ScreenToWorldPoint(Input.mousePosition) - transform.localPosition;
        radIncline = CalcNewIncline(angleVector, radIncline);

        // Rotate Cannon
        transform.eulerAngles = new Vector3(0, 0, radIncline * 180/Mathf.PI);

        //Left click
        if (Input.GetMouseButtonDown(0))
        {
            //if in cannon scene fire cannon
            if (!isFiring)
            {
                // Disabling because it's cooler to look at while testing
                //isFiring = true; 

                //fire cannon
                Launch();
            }
        }
    }

    private void Launch()
    {
        // Instantiate the Dice Prefab at firePoint position
        GameObject Dice = Instantiate(DicePrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = Dice.GetComponent<Rigidbody2D>();

        // Calculate the velocity the Dice should launch based on the angle of the cannon
        Vector2 _initialVelocity = new Vector2(Mathf.Cos(transform.localEulerAngles.z * Mathf.PI / 180) * Speed, Mathf.Sin(transform.localEulerAngles.z * Mathf.PI / 180) * Speed);

        rb.AddForce(_initialVelocity, ForceMode2D.Impulse);
    }



    private float CalcNewIncline(Vector2 angleVector, float oldRadIncline)
    {
        float newRadIncline = (Mathf.Atan(angleVector.y / angleVector.x));

        Debug.Log(newRadIncline);

        if(newRadIncline > (_maxDegree * Mathf.Deg2Rad))
        {
            return oldRadIncline;
        }

        if(newRadIncline < (_minDegree * Mathf.Deg2Rad))
        {
            return oldRadIncline;
        }

        return newRadIncline;
    }
}
