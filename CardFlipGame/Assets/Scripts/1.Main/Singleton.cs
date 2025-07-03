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
                Debug.LogWarning("[Singleton] 애플리케이션이 종료 중입니다. 인스턴스를 반환하지 않습니다.");
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
        //보드 초기화
        boardScript.firstCard = null;
        boardScript.secondCard = null;
        boardScript.CurrentCardCount = 0;

        //시간 초기화
        curruntTime = 30.00f;
        limitTime = 00.0f; // 제한 시간 초기화

        //사운드 매니저 초기화
        soundManager.audioSource.pitch = 1f; // 음악 속도 초기화

        //UI 매니저 초기화
        uIManagerManager.endPanel.SetActive(false);
        uIManagerManager.timeTxt.text = curruntTime.ToString("N2");
    }
}
