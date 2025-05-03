using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffect : MonoBehaviour
{
    public static AudioEffect audioEffect;

    AudioSource Effect;

    public AudioClip audioClick;
    public AudioClip audioSkill;
    public AudioClip audioDamaged;
    public AudioClip audioShield;
    public AudioClip audioItem;
    public AudioClip audioDie;
    public AudioClip audioClear;

    private void Awake()
    {
        if (audioEffect == null) audioEffect = this;
        else Destroy(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        Effect = gameObject.GetComponent<AudioSource>();
    }
    public void SkillSound()
    {
        Effect.PlayOneShot(audioSkill);
    }
    public void DamagedSound()
    {
        Effect.PlayOneShot(audioDamaged);
    }
    public void ShieldSound()
    {
        Effect.PlayOneShot(audioShield);
    }
    public void ItemSound()
    {
        Effect.PlayOneShot(audioItem);
    }
    public void ClickSound()
    {
        Effect.PlayOneShot(audioClick);
    }
    public void ClearSound()
    {
        Effect.PlayOneShot(audioClear);
    }
    public void DieSound()
    {
        Effect.PlayOneShot(audioDie);
    }
}
