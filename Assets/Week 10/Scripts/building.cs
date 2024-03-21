using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class building : MonoBehaviour
{
    public GameObject[] buildingParts;
    public float Speed = 1.5f;
    public float Gap = 0.1f;

    void Start()
    {
        StartCoroutine(ZoomInSequence());
    }

    IEnumerator ZoomInSequence()
    {
        foreach (GameObject part in buildingParts)
        {
            float TargetTime = 0f;
            Vector3 NowScale = Vector3.zero;
            Vector3 targetScale = part.transform.localScale;

            while (TargetTime < Speed)
            {
                part.transform.localScale = Vector3.Lerp(NowScale, targetScale, (TargetTime / Speed));
                TargetTime += Time.deltaTime;
                yield return null;
            }

            part.transform.localScale = targetScale;
            yield return new WaitForSeconds(Gap);
        }
    }
}
