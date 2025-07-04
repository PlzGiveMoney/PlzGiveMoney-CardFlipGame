using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;
using System;
using Random = UnityEngine.Random;

public class Board : MonoBehaviour
{
    public int CurrentCardCount; //남은 쌍 갯수

    public Card firstCard;
    public Card secondCard;

    public IEnumerator CreateCard(int Stage)
    {
        int pairCount;

        // 스테이지에 맞는 카드 갯수 설정
        switch (Stage)
        {
            case 1: pairCount = Convert.ToInt32(LevelEnum.Level1); break;
            case 2: pairCount = Convert.ToInt32(LevelEnum.Level2); break;
            case 3: pairCount = Convert.ToInt32(LevelEnum.Level3); break;
            case 4: pairCount = Convert.ToInt32(LevelEnum.Level4); break;
            case 5: pairCount = Convert.ToInt32(LevelEnum.Level5); break;
            default: pairCount = -1; break;
        }

        CurrentCardCount = pairCount;

        // 랜덤 카드 배열 생성
        int[] arr = ChooseCard(pairCount);
        int cardCount = arr.Length;

        // 행, 열 계산 (정사각형에 가깝게)
        int columns = Mathf.CeilToInt(Mathf.Sqrt(cardCount));
        int rows = Mathf.CeilToInt((float)cardCount / columns);

        float cardSpacing = 1.2f; // 카드 간격

        // 전체 폭/높이 계산
        float totalWidth = (columns - 1) * cardSpacing;
        float totalHeight = (rows - 1) * cardSpacing;

        // 중앙 정렬 오프셋
        Vector2 startPos = new Vector2(-totalWidth / 2f, totalHeight / 2f);

        arr = arr.OrderBy(x => Random.Range(0f, 1f)).ToArray();

        for (int i = 0; i < cardCount; i++)
        {
            int row = i / columns;
            int col = i % columns;

            // 카드 생성
            GameObject go = Instantiate(Singleton.Instance.cardPrefab);
            go.transform.SetParent(this.transform);

            // 카드 생성 사운드 재생
            Singleton.Instance.soundManager.creadtCardSFXPlay();

            // 카드 스프라이트 입력
            Transform front = go.transform.Find("Front");
            SpriteRenderer sr = front.GetComponent<SpriteRenderer>();
            sr.sprite = Singleton.Instance.spriteListSO.sprites[arr[i]];

            // 카드 위치 계산 (중앙 정렬)
            float x = startPos.x + col * cardSpacing;
            float y = startPos.y - row * cardSpacing;
            Vector2 targetPos = new Vector2(x, y);

            go.transform.position = new Vector2(0, -5f); // 시작 위치
            go.transform.DOMove(targetPos, 0.3f).SetEase(Ease.OutQuad);

            var cardComp = go.GetComponent<Card>();
            cardComp.index = arr[i];

            yield return new WaitForSeconds(0.1f);
        }
    }

    public int[] ChooseCard(int pairCount)
    {
        //sprite 인덱스로 사용가능한 숫자 리스트 생성
        List<int> availableNumbers = new List<int>();

        for (int i = 0; i < CurrentCardCount; i++)
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

        return arr;
    }

    public void MatchCard()
    {
        if (firstCard.index == secondCard.index)
        {
            Singleton.Instance.soundManager.successSFXPlay();
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            Singleton.Instance.boardScript.CurrentCardCount -= 1;
            if (Singleton.Instance.boardScript.CurrentCardCount == 0)
            {
                Singleton.Instance.soundManager.stageClearSFXPlay();
                Singleton.Instance.uIManagerManager.clearPanle.SetActive(true);

                Singleton.Instance.gameManager.gameState = GameState.End;
            }
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
            Singleton.Instance.soundManager.missSFXPlay();
        }
        firstCard = null;
        secondCard = null;
    }

}