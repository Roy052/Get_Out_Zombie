using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : Singleton
{
    public enum SFX
    {
        Siren = 0,
        Door = 1,
        Zombie = 2,
    }

    public AudioSource zombieAudioSource;
    public AudioSource sfxAudioSource;

    public AudioClip bgmClip;
    public AudioClip[] sfxClip;

    private void Awake()
    {
        if (sfxManager == null)
            sfxManager = this;
        else
            Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        if (sfxManager == this)
            sfxManager = null;
    }

    public void PlayZombie()
    {
        zombieAudioSource.Play();
    }

    public void PlaySFX(SFX sfx)
    {
        sfxAudioSource.Stop();
        sfxAudioSource.clip = sfxClip[(int)sfx];
        sfxAudioSource.Play();
    }
}
