using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class building : MonoBehaviour
{
    public GameObject[] buildingParts;
    public float totalAnimationDuration = 1.5f;
    public float gapBetweenPhases = 0.1f;

    void Start()
    {
        StartCoroutine(ZoomInSequence());
    }

    IEnumerator ZoomInSequence()
    {
        foreach (GameObject part in buildingParts)
        {
            yield return StartCoroutine(ZoomGameObject(part.transform));
            yield return new WaitForSeconds(gapBetweenPhases);
        }
    }

    IEnumerator ZoomGameObject(Transform objTransform)
    {
        Vector3 initialScale = Vector3.zero;
        Vector3 targetScale = objTransform.localScale;

        float phaseDuration = totalAnimationDuration / 3f;
        float elapsedTime = 0f;

        while (elapsedTime < phaseDuration)
        {
            objTransform.localScale = Vector3.Lerp(initialScale, targetScale, (elapsedTime / phaseDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        objTransform.localScale = targetScale;
    }
}
