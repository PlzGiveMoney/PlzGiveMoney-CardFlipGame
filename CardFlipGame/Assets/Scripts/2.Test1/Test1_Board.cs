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
    public int cardCount;//사진 개수
    //public static Text1_Board Instance; 보드는 싱글톤으로 안하는게 좋을듯

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
        //sprite의 개수를 변수로 그 안의 숫자를 랜덤하게 카드의 개수만큼 뽑아서 index를 참조할 배열에 넣는다.인데 간단하게 할 방법이 없을까?
        cardCount = spriteListSO.sprites.Count; 
        pairCount = stageInCard/2;// 쌍 개수

        //sprite 인덱스로 사용가능한 숫자 리스트 생성
        List<int> availableNumbers = new List<int>();
        for (int i = 0; i < cardCount; i++)
        {
            availableNumbers.Add(i);
        }

        //pairCount만큼 랜덤하게 뽑기 (중복 X)
        List<int> selectedNumbers = new List<int>();
        while (selectedNumbers.Count < pairCount)
        {
            //availableNumbers에서 선택된 번호를 제거해서 중복을 방지한다.
            int randIndex = Random.Range(0, availableNumbers.Count);
            selectedNumbers.Add(availableNumbers[randIndex]);
            availableNumbers.RemoveAt(randIndex);
        }

        int[] arr = new int[pairCount * 2];
        for (int i = 0; i < pairCount; i++)
        {
            arr[i * 2] = selectedNumbers[i];
            arr[i * 2 + 1] = selectedNumbers[i];
        }
        arr = arr.OrderBy(x => Random.Range(0f, 1f)).ToArray();

        //Debug.Log("배열 확인용" + string.Join(", ", arr));

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