using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siren : InteractiveObject
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] sirenSprites;
    public float time;

    Coroutine curCoroutine = null;
    float currentTime = 0f;
    float delay = 0.5f;
    bool isPlaying = false;

    private void Update()
    {
        if (isPlaying == false)
            currentTime = 0f;

        if (isPlaying)
            currentTime += Time.deltaTime;
    }

    public override void OnClick()
    {
        if (Vector2.Distance(zombieAI.transform.position, transform.position) > 20)
            return;

        if (isPlaying && currentTime < delay)
            return;

        base.OnClick();
        if (curCoroutine != null)
            StopCoroutine(curCoroutine);
        StartCoroutine(GoOffSiren());
    }

    IEnumerator GoOffSiren()
    {
        isPlaying = true;
        spriteRenderer.sprite = sirenSprites[1];
        zombieAI.AddInformation(InfoType.Audio, transform.position);
        yield return new WaitForSeconds(time);
        spriteRenderer.sprite = sirenSprites[0];
        isPlaying = false;
    }
}

