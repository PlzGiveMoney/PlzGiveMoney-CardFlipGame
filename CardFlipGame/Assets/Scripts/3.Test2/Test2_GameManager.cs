//using System.Linq;
//using UnityEngine;
//using UnityEngine.UI;

//public class Test2_GameManager : MonoBehaviour
//{
//    public Text timeTxt;
//    public GameObject endTxt;
//    float time = 0.0f;
//    public Transform cards;
//    public GameObject card;
//    public static Test2_GameManager Instance; 
//    public Test2_Card firstCard;
//    public Test2_Card secondCard;
//    public int cardCount = 0;

//    public void Awake()
//    {
//        if (Instance == null)
//        {
//            Instance = this;
//        }
//    }

//    void Start()
//    {
//        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
//        arr = arr.OrderBy(x => Random.Range(0f, 7f)).ToArray();

//        for (int i = 0; i < 16; i++)
//        {
//            GameObject go = Instantiate(card, this.transform);

//            float x = (i % 4) * 1.4f - 2.1f;
//            float y = (i / 4) * 1.4f - 3.0f;

//            go.transform.position = new Vector2(x, y);
//            go.GetComponent<Card>().Setting(arr[i]);
//            cardCount = arr.Length;
//        }
//    }

//    void Update()
//    {
//        time += Time.deltaTime;
//        timeTxt.text = time.ToString("N2");
//    }

//    public void checkMatched()
//    {
//        if (firstCard.index == secondCard.index)
//        {
//            firstCard.DestroyCard();
//            secondCard.DestroyCard();
//            cardCount -= 2;

//            if (cardCount == 0)
//            {
//                endTxt.SetActive(true);
//                Time.timeScale = 0.0f;
//            }
//        }
//        else
//        {
//            firstCard.CloseCard();
//            secondCard.CloseCard();
//        }

//        firstCard = null;
//        secondCard = null;
//    }
//}
