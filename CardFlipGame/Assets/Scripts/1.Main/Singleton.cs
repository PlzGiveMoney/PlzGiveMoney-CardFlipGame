using UnityEngine;

public class Singleton : MonoBehaviour
{
    public GameObject board;
    public Board boardScript;
    public GameObject cardPrefab;

    public float limitTime = 00.0f;
    public float curruntTime = 30.00f;

    public SoundManager soundManager;
    public UIManager uIManagerManager;

    public int CardTypeCount;

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

    protected virtual void OnDestroy()
    {
        _applicationIsQuitting = true;
    }

    public void InitGame()
    {
        //���� �ʱ�ȭ
        boardScript.firstCard = null;
        boardScript.secondCard = null;
        boardScript.CurrentCardCount = 0;

        //�ð� �ʱ�ȭ
        curruntTime = 30.00f;
        limitTime = 00.0f; // ���� �ð� �ʱ�ȭ

        //���� �Ŵ��� �ʱ�ȭ
        soundManager.audioSource.pitch = 1f; // ���� �ӵ� �ʱ�ȭ

        //UI �Ŵ��� �ʱ�ȭ
        uIManagerManager.endPanel.SetActive(false);
        uIManagerManager.timeTxt.text = curruntTime.ToString("N2");
    }
}
