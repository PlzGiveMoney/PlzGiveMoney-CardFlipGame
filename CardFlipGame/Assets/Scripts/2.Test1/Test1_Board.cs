using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;

public class Test1_Board : MonoBehaviour
{
    public GameObject card;
    public SpriteListSO spriteListSO;
    public int stageInCard = 16;//임시지정한 변수 난이도 상승시 조절하기
    int pairCount;

    //public static Text1_Board Instance;

    private void Awake()
    {/*
         if (Instance == null)
        {
            Instance = this;
        }*/
    }


    void Start()
    {

    }

    public IEnumerator CreateCard()
    {
        pairCount = stageInCard / 2; // 쌍의 개수
        int[] arr = new int[stageInCard];
        for (int i = 0; i < pairCount; i++)
        {
            arr[i * 2] = i;
            arr[i * 2 + 1] = i;
        }
        arr = arr.OrderBy(x => Random.Range(0f, pairCount)).ToArray();
        for (int i = 0; i < stageInCard; i++)
        {
            // 카드 생성
            GameObject go = Instantiate(card);
            go.transform.position = new Vector2(0, -5f);
            // 카드 생성 사운드 재생
            Test1_SoundControl.Instance.creadtCardSFXPlay(); // 카드 생성 사운드 재생
            // 카드 스프라이트 입력
            Transform front = go.transform.Find("Front");
            SpriteRenderer sr = front.GetComponent<SpriteRenderer>();
            sr.sprite = spriteListSO.sprites[arr[i]];
            // 카드 위치 설정 후 이동
            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f - 3.0f;
            Vector2 targetPos = new Vector2(x, y);
            go.transform.DOMove(targetPos, 0.3f).SetEase(Ease.OutQuad);
            //index값, 컴포넌트 입력
            Test1_GameManager.Instance.cardCount = arr.Length;
            var cardComp = go.GetComponent<Test1_Card>();
            cardComp.index = arr[i];
            yield return new WaitForSeconds(0.1f); // 카드 생성 간격
        }
    }

}