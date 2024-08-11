using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractiveObject
{
    public Vector2 posStart;
    public Vector2 posEnd;
    public float moveTime;

    float currentTime = 0f;
    Coroutine curCoroutine = null;

    public override void OnSwitch()
    {
        base.OnSwitch();
        if (curCoroutine != null)
        {
            StopCoroutine(curCoroutine);
            curCoroutine = null;
        }
        isOn = !isOn;
        if (isOn)
            StartCoroutine(MoveDoor(posStart, posEnd, currentTime != 0 ? currentTime : moveTime));
        else
            StartCoroutine(MoveDoor(posEnd, posStart, currentTime != 0 ? currentTime : moveTime));
    }

    IEnumerator MoveDoor(Vector2 A, Vector2 B, float moveTime)
    {
        currentTime = 0f;
        while (currentTime < moveTime)
        {
            transform.position = Vector3.Lerp(A, B, currentTime / moveTime);
            currentTime += Time.deltaTime;
            yield return null;
        }

        curCoroutine = null;
    }
}
