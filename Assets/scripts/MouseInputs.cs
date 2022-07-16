using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputs : MonoBehaviour
{
    Vector3 CannonPos;
    float radIncline;
    float maxRotationPerFrame;
    // Start is called before the first frame update
    void Start()
    {
        //(x, y) TODO update to cannon anchor location
        CannonPos = new Vector2(5, 3);
        radIncline = 45;
        //TODO tie this into cannon object
        int maxRotDegree = 5;
        maxRotationPerFrame = maxRotDegree * MathF.PI / 180;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 angleVector = Input.mousePosition - CannonPos;
        radIncline = CalcNewIncline(angleVector, radIncline);

        //rotate cannon

        //Left click
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(Input.mousePosition);

            //TODO if in cannon scene fire cannon or ready to fire
            if(false)
            {
                //TODO get power
                //TODO fire cannon
            }
        }
    }

    private float CalcNewIncline(Vector2 angleVector, float oldRadIncline)
    {
        float newRadIncline = Mathf.Atan(angleVector.y / angleVector.x);

        if(MathF.Abs(oldRadIncline - newRadIncline) >= maxRotationPerFrame)
        {
            if (oldRadIncline > newRadIncline)
            {
                newRadIncline = oldRadIncline - maxRotationPerFrame;
            } 
            else
            {
                newRadIncline = oldRadIncline + maxRotationPerFrame;
            }
        }

        return newRadIncline;
    }
}
