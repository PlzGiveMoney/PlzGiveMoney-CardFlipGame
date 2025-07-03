//using DG.Tweening;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using Unity.Burst.Intrinsics;
//using UnityEngine;

//public class Test2_Board : MonoBehaviour
//{
//    //현재 남아있는 카드 카운트
//    public int currentCardCount = 0;

//    public Test2_Card card;

//    //요청한 배치에 따라서 배치한다
//    public IEnumerator CreateCard()
//    {
//        //pairCount만큼 랜덤하게 뽑기 (중복 X)
//        List<int> selectedNumbers = new List<int>();
//        while (selectedNumbers.Count < pairCount)
//        {
//            //availableNumbers에서 선택된 번호를 제거해서 중복을 방지한다.
//            int randIndex = Random.Range(0, availableNumbers.Count);
//            selectedNumbers.Add(availableNumbers[randIndex]);
//            availableNumbers.RemoveAt(randIndex);
//        }

//        int[] arr = new int[pairCount * 2];
//        for (int i = 0; i < pairCount; i++)
//        {
//            arr[i * 2] = selectedNumbers[i];
//            arr[i * 2 + 1] = selectedNumbers[i];
//        }
//        arr = arr.OrderBy(x => Random.Range(0f, 1f)).ToArray();

//        //Debug.Log("배열 확인용" + string.Join(", ", arr));

//        for (int i = 0; i < stageInCard; i++)
//        {
//            // 카드 생성
//            GameObject go = Instantiate(card);
//            go.transform.position = new Vector2(0, -5f);
//            // 카드 생성 사운드 재생
//            Test1_SoundControl.Instance.creadtCardSFXPlay(); // 카드 생성 사운드 재생
//            // 카드 스프라이트 입력
//            Transform front = go.transform.Find("Front");
//            SpriteRenderer sr = front.GetComponent<SpriteRenderer>();
//            sr.sprite = spriteListSO.sprites[arr[i]];
//            // 카드 위치 설정 후 이동
//            float x = (i % 4) * 1.4f - 2.1f;
//            float y = (i / 4) * 1.4f - 3.0f;
//            Vector2 targetPos = new Vector2(x, y);
//            go.transform.DOMove(targetPos, 0.3f).SetEase(Ease.OutQuad);
//            //index값, 컴포넌트 입력
//            Test1_GameManager.Instance.cardCount = arr.Length;
//            var cardComp = go.GetComponent<Test1_Card>();
//            cardComp.index = arr[i];
//            yield return new WaitForSeconds(0.1f); // 카드 생성 간격
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    public void checkMatched()
//    {
//        if (Singleton.Instance.firstCard.index == Singleton.Instance.secondCard.index)
//        {
//            Singleton.Instance.firstCard.DestroyCard();
//            Singleton.Instance.secondCard.DestroyCard();
//            currentCardCount -= 2;

//            if (currentCardCount == 0)
//            {
//                //UI Manager 호출
//                //endTxt.SetActive(true);
//                Time.timeScale = 0.0f;
//            }
//        }
//        else
//        {
//            Singleton.Instance.firstCard.CloseCard();
//            Singleton.Instance.secondCard.CloseCard();
//        }

//        Singleton.Instance.firstCard = null;
//        Singleton.Instance.secondCard = null;
//    }
//}
