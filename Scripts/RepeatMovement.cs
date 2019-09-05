﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatMovement : MonoBehaviour
{
    public Transform spawn;
    public Transform target;
    

    public Vector3 speed;

    private Transform myTrans;
    private Vector3 originPos;

    private void Awake()
    {
        myTrans = GetComponent<Transform>();

        originPos = myTrans.position;
    }


    public void SetSpeedX(float x)
    {
        speed.x = x;
    }

    public void SetSpeedY(float y)
    {
        speed.y = y;
    }

    private void Update()
    {
        myTrans.Translate(speed * Time.deltaTime);

        float dis  = (target ? target.transform.position.x : 0.0f)
                    - myTrans.position.x;
        
        if(Mathf.Abs(dis) <= 1.0f)
        {
            if (spawn)
                myTrans.position = spawn.position;
            else
                myTrans.position = originPos;
        }
    }
}
