using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using AdvancedUnityPlugin;

public class DistanceCalculator : MonoBehaviour
{
    public GameObject target;
    public float distance;

    public FloatUnityEvent onLessThan;

    public void Update()
    {
        if (!target)
            return;

        float result = Vector2.Distance(this.transform.position, target.transform.position);
        if (Mathf.Abs(result) < Mathf.Abs(distance))
            onLessThan.Invoke(result);
    }
}
