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
    private bool hasFired;
    private Camera _cam;

    Vector3 CannonPos;
    float radIncline;
    float maxRotationPerFrame;
    // Start is called before the first frame update
    void Start()
    {
        //(x, y) init Cannon position for calculations place holder
        //CannonPos = Cannon.transform.position;
        //radIncline = Cannon.transform.localEulerAngles.z * Mathf.PI / 180;
        //could do a call to the cannon object for quick updates for what feels/looks right
        int maxRotDegree = 5;
        maxRotationPerFrame = maxRotDegree * MathF.PI / 180;

        hasFired = false;

        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 angleVector = _cam.ScreenToWorldPoint(Input.mousePosition) - transform.localPosition;
        radIncline = CalcNewIncline(angleVector, radIncline);
        transform.eulerAngles = new Vector3(0, 0, radIncline * 180/Mathf.PI);

        //Vector3 mouse = Input.mousePosition;
        //Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(new Vector3(
        //                                                    mouse.x,
        //                                                    mouse.y,
        //                                                    transform.position.y));
        //Vector3 forward = mouseWorld - transform.position;
        //transform.rotation = Quaternion.LookRotation(forward, Vector3.up);

        //Left click
        if (Input.GetMouseButtonDown(0))
        {
            
            //rotate cannon

            //if in cannon scene fire cannon
            if (!hasFired)
            {
                hasFired = true;
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

        if(newRadIncline > 85 * Mathf.Deg2Rad)
        {
            return oldRadIncline;
        }

        if(newRadIncline < 5 * Mathf.Deg2Rad)
        {
            return oldRadIncline;
        }

        //if (MathF.Abs(oldRadIncline - newRadIncline) >= maxRotationPerFrame)
        //{
        //    if (oldRadIncline > newRadIncline)
        //    {
        //        newRadIncline = oldRadIncline - maxRotationPerFrame;
        //    }
        //    else
        //    {
        //        newRadIncline = oldRadIncline + maxRotationPerFrame;
        //    }
        //}

        return newRadIncline;
    }
}
