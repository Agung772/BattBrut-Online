using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource audioSourceBGM;
    public AudioSource audioSourceSFX;

    public Slider sliderBGM;
    public Slider sliderSFX;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    private void Start()
    {
        if (sliderBGM != null) sliderBGM.value = audioSourceBGM.volume;
        if (sliderSFX != null) sliderSFX.value = audioSourceSFX.volume;

    }



    [Header("BGM")]
    public AudioClip mainmenuBgm;
    public AudioClip gameplayBgm;


    public void SetBGM(AudioClip value)
    {
        if (audioSourceBGM.clip == value) return;

        if (value == mainmenuBgm)
        {
            audioSourceBGM.clip = mainmenuBgm;
            audioSourceBGM.Play();
        }
        else if (value == gameplayBgm)
        {
            audioSourceBGM.clip = gameplayBgm;
            audioSourceBGM.Play();
        }
        else
        {
            Debug.Log("Missing Audio : " + value);
        }
    }
    [Header("SFX")]
    public AudioClip SFXDash;
    public AudioClip SFXJump;
    public AudioClip SFXSkill1;
    public AudioClip SFXSkill2;
    public AudioClip SFXSkill3;
    public AudioClip SFXSkill4;

    public void SetSFX(AudioClip value)
    {
        if (value == SFXDash)
        {
            audioSourceSFX.PlayOneShot(SFXDash);
        }
        else if (value == SFXJump)
        {
            audioSourceSFX.PlayOneShot(SFXJump);
        }
        else if (value == SFXSkill1)
        {
            audioSourceSFX.PlayOneShot(SFXSkill1);
        }
        else if (value == SFXSkill2)
        {
            audioSourceSFX.PlayOneShot(SFXSkill2);
        }
        else if (value == SFXSkill3)
        {
            audioSourceSFX.PlayOneShot(SFXSkill3);
        }
        else if (value == SFXSkill4)
        {
            audioSourceSFX.PlayOneShot(SFXSkill4);
        }
        else
        {
            Debug.Log("Missing Audio : " + value);
        }
    }
}
