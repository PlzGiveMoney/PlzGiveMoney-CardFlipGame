using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Ãß°¡

public class Test1_GameManager : MonoBehaviour
{
    public Text timeTxt;
    float time = 0.00f;
    public static Test1_GameManager Instance;

    public Test1_Card firstCard;
    public Test1_Card secondCard;

    public int cardCount = 0;
    public GameObject endTxt;

    public float limitTime = 30.0f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 1.0f;
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        isTimeCheck();
    }

    public void isMatched()
    {
        if (firstCard.index == secondCard.index)
        {
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            if (cardCount == 0)
            {
                endTxt.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
        else
        {
        firstCard.CloseCard();
        secondCard.CloseCard();
        }
        firstCard = null;
        secondCard = null;
    }

    public void isTimeCheck()
    {
        if(time >= limitTime)
        {
            endTxt.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void checkMatched()
    {
        if(firstCard.index == secondCard.index)
        {
            firstCard.DestroyCard();
            secondCard.DestroyCard();
        }
        else
        {
            firstCard.DestroyCard();
            secondCard.DestroyCard();
        }
        firstCard = null;
        secondCard = null;
    }
}
