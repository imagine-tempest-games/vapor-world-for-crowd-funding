using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DizzyController : MonoBehaviour
{
    public Material blurMaterial;
    public Texture dizzyTexture;
    [Header("")]
    public float blurRecoverySpeed;
    public float waveSpeed;

    public UnityEvent onDizzy;
    public UnityEvent onRecovery;

    private Texture originBump;
    private float originBumpOffsetX;
    private float originBumpOffsetY;
    private float originSize;
    private float originAmt;

    private float offsetX;
    private float offsetY;

    private void Awake()
    {
        originBump = blurMaterial.GetTexture("_BumpMap");
        offsetX = originBumpOffsetX = blurMaterial.GetTextureOffset("_BumpMap").x;
        offsetY = originBumpOffsetY = blurMaterial.GetTextureOffset("_BumpMap").y;
        originAmt  = blurMaterial.GetFloat("_BumpAmt");
        originSize = blurMaterial.GetFloat("_Size");
    }

    private void OnDestroy()
    {
        Reset();
    }

    public void RecoveryDizzy()
    {
        StartCoroutine(RecoveryDizzying());
    }

    private IEnumerator RecoveryDizzying()
    {
        float blurSize = originSize;

        StartCoroutine(DecreaseDistortion());

        blurMaterial.SetTexture("_BumpMap", dizzyTexture);

        while(true)
        {
            yield return null;

            Wave();

            blurSize -= Time.deltaTime * blurRecoverySpeed;

            blurMaterial.SetFloat("_Size", blurSize);

            if (blurSize <= 0.0f)
                break;
        }

        onRecovery.Invoke();
        blurMaterial.SetFloat("_Size", 0);
    }

    private IEnumerator DecreaseDistortion()
    {
        float distortion = blurMaterial.GetFloat("_BumpAmt");
        while (distortion > 0)
        {
            yield return null;

            distortion -= Time.deltaTime * 4.0f;

            blurMaterial.SetFloat("_BumpAmt", distortion);
        }
    }

    private void Wave()
    {
        offsetY += Time.deltaTime * waveSpeed;
        if (offsetY >= 1.1f)
            offsetY = -1.1f;

        offsetX += Time.deltaTime * waveSpeed * 2;
        if (offsetX >= 1.1f)
            offsetX = -1.1f;
        
        blurMaterial.SetTextureOffset("_BumpMap", new Vector2(offsetX, offsetY));
    }

    private void Reset()
    {
        blurMaterial.SetTexture("_BumpMap", originBump);
        blurMaterial.SetFloat("_Size", originSize);
        blurMaterial.SetTextureOffset("_BumpMap", new Vector2(originBumpOffsetX, originBumpOffsetY));
        blurMaterial.SetFloat("_BumpAmt", originAmt);
    }
}
