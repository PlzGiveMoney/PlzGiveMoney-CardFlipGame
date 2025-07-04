using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //제한 시간이 나오는 텍스트
    public Text timeTxt;

    //게임이 끝났을 때 나오는 패널
    public GameObject clearPanle;

    public GameObject failPanel;

    public GameObject stageHelpPanel;

    public GameObject ChallengeHelpPanel;

    public GameObject MainUI;

    public GameObject GameUI;

    public GameObject MainBackGround;

    public GameObject MainMenuBtn;

    public Vector3 Origin;
    private void Start()
    {
        Origin = MainBackGround.transform.localPosition;
    }
    // Update is called once per frame
    void Update()
    {
        switch (Singleton.Instance.gameManager.gameState)
        {
            case GameState.Start:
                MainUI.SetActive(true);
                GameUI.SetActive(false);
                MainBackGround.SetActive(true);
                MainMenuBtn.SetActive(false);
                coroutine = StartCoroutine(BackGroundMove());
                break;
            case GameState.Playing:
                MainUI.SetActive(false);
                GameUI.SetActive(true);
                MainBackGround.SetActive(false);
                MainMenuBtn.SetActive(true);
                StopCoroutine(coroutine);
                MainBackGround.transform.localPosition = Origin; // 배경 위치 초기화
                Singleton.Instance.curruntTime -= Time.deltaTime;
                timeTxt.text = Singleton.Instance.curruntTime.ToString("N2");
                IsTimeOver();
                break;
            case GameState.End:
                MainUI.SetActive(false);
                GameUI.SetActive(true);

                if(Singleton.Instance.curruntTime >= Singleton.Instance.limitTime)
                {
                    clearPanle.SetActive(true);
                    failPanel.SetActive(false);
                }
                else
                {
                    clearPanle.SetActive(false);
                    failPanel.SetActive(true);
                }

                break;
        }
    }

    public void IsTimeOver()
    {
        if (Singleton.Instance.curruntTime < 10.0f)
        {
            Singleton.Instance.soundManager.audioSource.pitch = 2f;
        }
        //여러번 실행된 후에 정지해서 같았을 때 조건을 빼고 0으로 맞추도록 수정
        if (Singleton.Instance.curruntTime < Singleton.Instance.limitTime)
        {
            Singleton.Instance.soundManager.stageFailSFXPlay();
            failPanel.SetActive(true);
            Time.timeScale = 0.0f;
            Singleton.Instance.curruntTime = 0;
        }
    }
    public GameObject OptionUI;

    
    public void OnOptionButton()
    {
        //Test1_GameManager.Instance.gameState = Test1_GameManager.GameState.Option;
        OptionUI.SetActive(true);
    }

    public void OnOptionCloseButton()
    {
        OptionUI.SetActive(false);
    }

    public void OnMainButton()
    {
        Singleton.Instance.gameManager.gameState = GameState.Start;
        OptionUI.SetActive(false);
    }
    public void OnStageButton()
    {
        //스테이지 선택 UI 나옴
    }

    public void OnStartButton()
    {
        if(Singleton.Instance.gameManager.gameState == GameState.Start)
        {
            Singleton.Instance.Stage = 0; // 스테이지 초기화
        }
        Singleton.Instance.gameManager.setGame();
    }

    public void EnterStageHelp()
    {
        //스테이지 도움말 UI 나옴
        stageHelpPanel.SetActive(true);
    }
    public void ExitStageHelp()
    {
        //스테이지 도움말 UI 꺼짐
        stageHelpPanel.SetActive(false);
    }
    public void EnterChallengeHelp()
    {
        //챌린지 도움말 UI 나옴
        ChallengeHelpPanel.SetActive(true);
    }
    public void ExitChallengeHelp()
    {
        //챌린지 도움말 UI 꺼짐
        ChallengeHelpPanel.SetActive(false);
    }

    Coroutine coroutine;
    public IEnumerator BackGroundMove()
    {
        float moveInterval = 0.5f; // 움직임 간격(초)
        float moveDuration = 50f; // 한 번 움직임에 걸리는 시간(초)
        float moveStrength = 2000f; // 한 번에 이동할 최대 거리

        Vector3 origin = MainBackGround.transform.position;

        while (true)
        {
            // 오른쪽 위 방향 (1, 1) 정규화
            Vector2 direction = new Vector2(1f, 1f).normalized;
            float strength = moveStrength;
            Vector3 targetPos = origin + (Vector3)(direction * strength);

            // 부드럽게 이동
            float t = 0f;
            Vector3 startPos = MainBackGround.transform.position;
            while (t < moveDuration)
            {
                t += Time.deltaTime;
                MainBackGround.transform.position = Vector3.Lerp(startPos, targetPos, t / moveDuration);
                yield return null;
            }
            MainBackGround.transform.position = targetPos;

            // 다음 움직임까지 대기
            yield return new WaitForSeconds(moveInterval);
        }
    }
}