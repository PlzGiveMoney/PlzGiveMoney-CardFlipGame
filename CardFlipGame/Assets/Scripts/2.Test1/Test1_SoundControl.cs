//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class Test1_SoundControl : MonoBehaviour
//{
//    public AudioSource audioSource;
//    public AudioSource sfxSource;

//    public AudioClip backGroundMusic;
//    public AudioClip cardFlipSFX;
//    public AudioClip successSFX;
//    public AudioClip missSFX;
//    public AudioClip stageClearSFX;
//    public AudioClip stageFailSFX;
//    public AudioClip creadtCardSFX;

//    public Slider volumeSlider;
//    public Slider sfxvolumeSlider;

//    public static Test1_SoundControl Instance;

//    private void Awake()
//    {
//        if (Instance == null)
//        {
//            Instance = this;
//        }
//        Init();

//    }
//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//    public void Init()
//    {
//        audioSource.volume = 0.1f;
//        sfxSource.volume = 0.7f;

//        volumeSlider.value = audioSource.volume;
//        sfxvolumeSlider.value = sfxSource.volume;

//        volumeSlider.onValueChanged.AddListener(SetVolume);
//        sfxvolumeSlider.onValueChanged.AddListener(SetSFXVolume);
       
//    }

//    public void PlayStageMusic()
//    {
//        audioSource.clip = backGroundMusic;
//        audioSource.loop = true;
//        audioSource.Play();
//    }

//    public void PlaySFX(AudioClip clip)
//    {
//        sfxSource.PlayOneShot(clip);
//    }

//    public void SetVolume(float value)
//    {
//        audioSource.volume = value;
//    }

//    // SFX 볼륨 조절 메서드 추가
//    public void SetSFXVolume(float value)
//    {
//        sfxSource.volume = value;
//    }

//    public void cardFlipSFXPlay() => PlaySFX(cardFlipSFX);
//    public void successSFXPlay() => PlaySFX(successSFX);
//    public void missSFXPlay() => PlaySFX(missSFX);
//    public void stageClearSFXPlay() => PlaySFX(stageClearSFX);
//    public void stageFailSFXPlay() => PlaySFX(stageFailSFX);
//    public void creadtCardSFXPlay() => PlaySFX(creadtCardSFX);
//}
