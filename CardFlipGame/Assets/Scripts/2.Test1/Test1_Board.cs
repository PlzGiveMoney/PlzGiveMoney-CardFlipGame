using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Text1_Board : MonoBehaviour
{
    public GameObject card;
    public SpriteListSO spriteListSO;
    public int stageInCard = 16;//임시지정한 변수 난이도 상승시 조절하기

    void Start()
    {
        int pairCount = stageInCard / 2; // 쌍의 개수
        int[] arr = new int[stageInCard];
        for (int i = 0; i < pairCount; i++)
        {
            arr[i * 2] = i;
            arr[i * 2 + 1] = i;
        }
        arr = arr.OrderBy(x => Random.Range(0f, pairCount)).ToArray();
        for (int i = 0; i < stageInCard; i++)
        {
            GameObject go = Instantiate(card);
            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f - 3.0f;
            go.transform.position = new Vector2(x, y);

            var cardComp = go.GetComponent<Test1_Card>();
            cardComp.index = arr[i];

            Transform front = go.transform.Find("Front");
            SpriteRenderer sr = front.GetComponent<SpriteRenderer>();
            sr.sprite = spriteListSO.sprites[arr[i]];
            Test1_GameManager.Instance.cardCount = arr.Length;
        }
    }
}