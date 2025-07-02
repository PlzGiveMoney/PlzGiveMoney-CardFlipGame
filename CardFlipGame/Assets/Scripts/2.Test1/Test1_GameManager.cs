using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 추가

public class Test1_GameManager : MonoBehaviour
{
    public Text timeTxt;
    float time = 30.00f;
    public static Test1_GameManager Instance;

    public Test1_Card firstCard;
    public Test1_Card secondCard;

    public int cardCount = 0;
    public GameObject endTxt;
    public GameObject board;
    public Test1_Board test1_Board;

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
        SetComponent();
        SetGameData();
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        isTimeCheck();
    }
    public void SetComponent()
    { 
        test1_Board = board.GetComponent<Test1_Board>();
    }

    public void SetGameData()//나중에 변수값 초기화 할 때 사용
    { 
        time = 30.00f;
        timeTxt.text = time.ToString("N2");
        cardCount = 0;
        firstCard = null;
        secondCard = null;
        endTxt.SetActive(false);
        limitTime = 00.0f; // 제한 시간 초기화
        Test1_SoundControl.Instance.audioSource.pitch = 1f; // 음악 속도 초기화
    }
    public void StartGame()
    {
        StartCoroutine(test1_Board.CreateCard());
        Time.timeScale = 1.0f;
        PlayBackgroundMusic();
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
        //여러번 실행된 후에 정지해서 같았을 때 조건을 빼고 0으로 맞추도록 수정
        if (time < limitTime)
        {
            Test1_SoundControl.Instance.stageFailSFXPlay();
            endTxt.SetActive(true);
            Time.timeScale = 0.0f;
            time = 0;
        }
    }

}
