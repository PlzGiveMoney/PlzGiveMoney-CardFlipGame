using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Ãß°¡

public class Test1_GameManager : MonoBehaviour
{
    public Text timeTxt;
    float time = 30.00f;
    public static Test1_GameManager Instance;

    public Test1_Card firstCard;
    public Test1_Card secondCard;

    public int cardCount = 0;
    public GameObject endTxt;

    public float limitTime = 00.0f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        Time.timeScale = 1.0f;
        PlayBackgroundMusic();
    }

    // Update is called once per frame
    void Update()
    {

        time -= Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        isTimeCheck();
    }

    public void PlayBackgroundMusic()
    {
        Test1_SoundControl.Instance.PlayStageMusic();
    }

    public void isMatched()
    {
        if (firstCard.index == secondCard.index)
        {
            Test1_SoundControl.Instance.successSFXPlay();
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            if (cardCount == 0)
            {
                Test1_SoundControl.Instance.stageClearSFXPlay();
                endTxt.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
        else
        {
        firstCard.CloseCard();
        secondCard.CloseCard();
        Test1_SoundControl.Instance.missSFXPlay();
        }
        firstCard = null;
        secondCard = null;
    }

    public void isTimeCheck()
    {
        if (time < 10.0f)
        {
            Test1_SoundControl.Instance.audioSource.pitch = 2f;
        }

        if (time <= limitTime)
        {
            Test1_SoundControl.Instance.stageFailSFXPlay();
            endTxt.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

}
