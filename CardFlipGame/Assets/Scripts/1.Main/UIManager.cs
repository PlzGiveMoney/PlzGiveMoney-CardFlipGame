using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public Text timeTxt;

    //게임이 끝났을 때 나오는 패널
    public GameObject clearPanle;

    public GameObject failPanel;

    public GameObject stageHelpPanel;

    public GameObject ChallengeHelpPanel;

    public GameObject MainUI;

    public GameObject GameUI;

    public GameObject MainBackGround;

    public GameObject StagePanel;

    public GameObject OptionMainBtn;

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
                Singleton.Instance.backGround.SetActive(false);
                MainUI.SetActive(true);
                GameUI.SetActive(false);
                MainBackGround.SetActive(true);
                failPanel.SetActive(false);
                OptionMainBtn.SetActive(false);
                coroutine = StartCoroutine(BackGroundMove());
                break;

            case GameState.Playing:
                MainUI.SetActive(false);
                GameUI.SetActive(true);
                MainBackGround.SetActive(false);
                clearPanle.SetActive(false);
                StagePanel.SetActive(false);
                OptionMainBtn.SetActive(true);
                StopCoroutine(coroutine);
                MainBackGround.transform.localPosition = Origin; // ��� ��ġ �ʱ�ȭ
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
        //������ ����� �Ŀ� �����ؼ� ������ �� ������ ���� 0���� ���ߵ��� ����
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
        Singleton.Instance.soundManager.audioSource.pitch = 1f; // ���� �ӵ� �ʱ�ȭ

        OptionUI.SetActive(false);
    }
    public void OnStageButton()
    {
        StagePanel.SetActive(true);
    }

    public void StageSettingButton(int num)
    {
        Singleton.Instance.Stage = num-1; // 스테이지 초기화
        Singleton.Instance.gameManager.setGame();
    }

    public void OnStartButton()
    {
        if(Singleton.Instance.gameManager.gameState == GameState.Start)
        {
            Singleton.Instance.Stage = 0; // 스테이지 초기화
        }
        Singleton.Instance.gameManager.setGame();
        Singleton.Instance.backGround.SetActive(false);
    }

    public void OnRestartButton()
    {
        Singleton.Instance.gameManager.setGame();
        Singleton.Instance.backGround.SetActive(false);
    }

    public void EnterStageHelp()
    {
        //�������� ���� UI ����
        stageHelpPanel.SetActive(true);
    }
    public void ExitStageHelp()
    {
        //�������� ���� UI ����
        stageHelpPanel.SetActive(false);
    }
    public void EnterChallengeHelp()
    {
        //ç���� ���� UI ����
        ChallengeHelpPanel.SetActive(true);
    }
    public void ExitChallengeHelp()
    {
        //ç���� ���� UI ����
        ChallengeHelpPanel.SetActive(false);
    }

    Coroutine coroutine;
    public IEnumerator BackGroundMove()
    {
        float moveInterval = 0.5f; // ������ ����(��)
        float moveDuration = 50f; // �� �� �����ӿ� �ɸ��� �ð�(��)
        float moveStrength = 2000f; // �� ���� �̵��� �ִ� �Ÿ�

        Vector3 origin = MainBackGround.transform.position;

        while (true)
        {
            // ������ �� ���� (1, 1) ����ȭ
            Vector2 direction = new Vector2(1f, 1f).normalized;
            float strength = moveStrength;
            Vector3 targetPos = origin + (Vector3)(direction * strength);

            // �ε巴�� �̵�
            float t = 0f;
            Vector3 startPos = MainBackGround.transform.position;
            while (t < moveDuration)
            {
                t += Time.deltaTime;
                MainBackGround.transform.position = Vector3.Lerp(startPos, targetPos, t / moveDuration);
                yield return null;
            }
            MainBackGround.transform.position = targetPos;

            // ���� �����ӱ��� ���
            yield return new WaitForSeconds(moveInterval);
        }
    }
}