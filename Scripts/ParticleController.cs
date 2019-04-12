using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public Material material;
    public new ParticleSystem particleSystem;

    public float originAlpha;

    public void Awake()
    {
        originAlpha = material.GetColor("_TintColor").a * 100.0f;
    }

    public void SetColorAlpha(float alpha)
    {
        float value = (originAlpha) - (alpha * 0.01f);
        if (value > originAlpha)
            value = originAlpha;

        Color color = material.GetColor("_TintColor");

        color.a = value;

        material.SetColor("_TintColor", color);
    }
}
