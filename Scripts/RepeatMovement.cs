using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatMovement : MonoBehaviour
{
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

        float dis = Vector2.Distance(target.transform.position, myTrans.position);
        if(Mathf.Abs(dis) <= 1.0f)
        {
            myTrans.position = originPos;
        }
    }
}
