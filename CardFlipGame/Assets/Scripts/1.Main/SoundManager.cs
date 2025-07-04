using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource sfxSource;

    public AudioClip backGroundMusic;
    public AudioClip cardFlipSFX;
    public AudioClip successSFX;
    public AudioClip missSFX;
    public AudioClip stageClearSFX;
    public AudioClip stageFailSFX;
    public AudioClip creadtCardSFX;
    public GameObject audioListener;

    public Slider volumeSlider;
    public Slider sfxvolumeSlider;

    private void Awake()
    {
        AudioSource[] sources = audioListener.GetComponents<AudioSource>();
        audioSource = sources[0];
        sfxSource = sources[1];

        audioSource.volume = 0.1f;
        sfxSource.volume = 0.7f;
        //test
        volumeSlider.value = audioSource.volume;
        volumeSlider.onValueChanged.AddListener(SetVolume);

        sfxvolumeSlider.value = sfxSource.volume;
        sfxvolumeSlider.onValueChanged.AddListener(SetSFXVolume);
        PlayStageMusic();

    }

    public void PlayStageMusic()
    {
        audioSource.clip = backGroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void SetVolume(float value)
    {
        audioSource.volume = value;
    }

    // SFX ���� ���� �޼��� �߰�
    public void SetSFXVolume(float value)
    {
        sfxSource.volume = value;
    }

    public void cardFlipSFXPlay() => PlaySFX(cardFlipSFX);
    public void successSFXPlay() => PlaySFX(successSFX);
    public void missSFXPlay() => PlaySFX(missSFX);
    public void stageClearSFXPlay() => PlaySFX(stageClearSFX);
    public void stageFailSFXPlay() => PlaySFX(stageFailSFX);
    public void creadtCardSFXPlay() => PlaySFX(creadtCardSFX);
}
