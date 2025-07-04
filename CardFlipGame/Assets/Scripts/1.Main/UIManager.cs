using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //���� �ð��� ������ �ؽ�Ʈ
    public Text timeTxt;

    //������ ������ �� ������ �г�
    public GameObject endPanel;

    public GameObject stageHelpPanel;

    public GameObject ChallengeHelpPanel;

    public GameObject MainUI;

    public GameObject GameUI;

    public GameObject MainBackGround;

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
                coroutine = StartCoroutine(BackGroundMove());
                break;
            case GameState.Playing:
                MainUI.SetActive(false);
                GameUI.SetActive(true);
                MainBackGround.SetActive(false);
                Debug.Log("Playing State");
                StopCoroutine(coroutine);
                MainBackGround.transform.localPosition = Origin; // ��� ��ġ �ʱ�ȭ
                Singleton.Instance.curruntTime -= Time.deltaTime;
                timeTxt.text = Singleton.Instance.curruntTime.ToString("N2");
                IsTimeOver();
                break;
            case GameState.End:
                MainUI.SetActive(false);
                GameUI.SetActive(true);
                endPanel.SetActive(true);
                Time.timeScale = 0.0f;
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
            endPanel.SetActive(true);
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
        //Test1_GameManager.Instance.gameState = Test1_GameManager.GameState.Playing;
        OptionUI.SetActive(false);
    }

    public void OnMainButton()
    {
        //SceneManager.LoadScene("MainScean");
        Debug.Log("Main Button Clicked");
    }
    public void OnStageButton()
    {
        //�������� ���� UI ����
    }

    public void OnStartButton()
    {
        Singleton.Instance.gameManager.setGame();
    }

    public void OnRestartButton()
    {
        Singleton.Instance.gameManager.setGame();
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