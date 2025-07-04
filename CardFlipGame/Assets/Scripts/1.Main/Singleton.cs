using UnityEngine;
using System.Collections;

public class Singleton : MonoBehaviour
{
    public SpriteListSO spriteListSO;

    public GameObject cardPrefab;

    public GameObject board;
    public Board boardScript;

    public float limitTime = 00.0f;
    public float curruntTime = 30.00f;

    public SoundManager soundManager;
    public UIManager uIManagerManager;
    public GameManager gameManager;
    public SpriteRenderer backSprite;

    public GameObject backGround;
    public int CardTypeCount;

    public int Stage;
    private static Singleton _instance;
    private static bool _applicationIsQuitting = false;

    public static Singleton Instance
    {
        get
        {
            if (_applicationIsQuitting)
            {
                Debug.LogWarning("[Singleton] ���ø����̼��� ���� ���Դϴ�. �ν��Ͻ��� ��ȯ���� �ʽ��ϴ�.");
                return null;
            }

            if (_instance == null)
            {
                _instance = FindObjectOfType<Singleton>();
                if (_instance == null)
                {
                    var obj = new GameObject("Singleton");
                    _instance = obj.AddComponent<Singleton>();
                    DontDestroyOnLoad(obj);
                }
            }
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnDestroy()
    {
        _applicationIsQuitting = true;
    }

    public void InitGameDatas()
    {
        //���� �ʱ�ȭ
        boardScript.firstCard = null;
        boardScript.secondCard = null;
        boardScript.CurrentCardCount = 0;
        foreach (Transform child in board.transform)
        {
            Destroy(child.gameObject);
        }

        //�ð� �ʱ�ȭ
        curruntTime = 30.00f;
        limitTime = 00.0f; // ���� �ð� �ʱ�ȭ

        //���� �Ŵ��� �ʱ�ȭ
        soundManager.audioSource.pitch = 1f; // ���� �ӵ� �ʱ�ȭ

        //UI 매니저 초기화
        uIManagerManager.clearPanle.SetActive(false);
        uIManagerManager.failPanel.SetActive(false);
        uIManagerManager.timeTxt.text = curruntTime.ToString("N2");
    }
      public IEnumerator OpenPicture() 
      {
        backGround.SetActive(true);
        backSprite = backGround.GetComponent<SpriteRenderer>();
        for (int i = 0; i< spriteListSO.sprites.Count; i++)
        {
            backSprite.sprite = spriteListSO.sprites[i];
            Debug.Log("배경 스프라이트 변경: " + backSprite.sprite.name);
            yield return new WaitForSeconds(0.1f); // 카드 생성 간격
        }
        uIManagerManager.clearPanle.SetActive(true);
        gameManager.gameState = GameState.End;
      }
}
