using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;
using System;
using Random = UnityEngine.Random;

public class Board : MonoBehaviour
{
    public int CurrentCardCount; //���� �� ����

    public Card firstCard;
    public Card secondCard;

    public IEnumerator CreateCard(int Stage)
    {
        int pairCount;

        // ���������� �´� ī�� ���� ����
        switch (Stage)
        {
            case 1: pairCount = Convert.ToInt32(LevelEnum.Level1); break;
            case 2: pairCount = Convert.ToInt32(LevelEnum.Level2); break;
            case 3: pairCount = Convert.ToInt32(LevelEnum.Level3); break;
            case 4: pairCount = Convert.ToInt32(LevelEnum.Level4); break;
            case 5: pairCount = Convert.ToInt32(LevelEnum.Level5); break;
            case 6: pairCount = Convert.ToInt32(LevelEnum.Level6); break;
            case 7: pairCount = Convert.ToInt32(LevelEnum.Level7); break;
            default: pairCount = -1; break;
        }

        CurrentCardCount = pairCount;

        // ���� ī�� �迭 ����
        int[] arr = ChooseCard(pairCount);
        int cardCount = arr.Length;

        // ��, �� ��� (���簢���� ������)
        int columns = Mathf.CeilToInt(Mathf.Sqrt(cardCount));
        int rows = Mathf.CeilToInt((float)cardCount / columns);

        float cardSpacing = 1.2f; // ī�� ����

        // ��ü ��/���� ���
        float totalWidth = (columns - 1) * cardSpacing;
        float totalHeight = (rows - 1) * cardSpacing;

        // �߾� ���� ������
        Vector2 startPos = new Vector2(-totalWidth / 2f, totalHeight / 2f);

        arr = arr.OrderBy(x => Random.Range(0f, 1f)).ToArray();

        for (int i = 0; i < cardCount; i++)
        {
            int row = i / columns;
            int col = i % columns;

            // ī�� ����
            GameObject go = Instantiate(Singleton.Instance.cardPrefab);
            go.transform.SetParent(this.transform);

            // ī�� ���� ���� ���
            Singleton.Instance.soundManager.creadtCardSFXPlay();

            // ī�� ��������Ʈ �Է�
            Transform front = go.transform.Find("Front");
            SpriteRenderer sr = front.GetComponent<SpriteRenderer>();
            sr.sprite = Singleton.Instance.spriteListSO.sprites[arr[i]];

            // ī�� ��ġ ��� (�߾� ����)
            float x = startPos.x + col * cardSpacing;
            float y = startPos.y - row * cardSpacing;
            Vector2 targetPos = new Vector2(x, y);

            go.transform.position = new Vector2(0, -5f); // ���� ��ġ
            go.transform.DOMove(targetPos, 0.3f).SetEase(Ease.OutQuad);

            var cardComp = go.GetComponent<Card>();
            cardComp.index = arr[i];

            yield return new WaitForSeconds(0.1f);
        }
    }

    public int[] ChooseCard(int pairCount)
    {
        //sprite �ε����� ��밡���� ���� ����Ʈ ����
        List<int> availableNumbers = new List<int>();

        for (int i = 0; i < Singleton.Instance.spriteListSO.sprites.Count; i++)
        {
            availableNumbers.Add(i);
        }

        //pairCount��ŭ �����ϰ� �̱� (�ߺ� X)
        List<int> selectedNumbers = new List<int>();

        while (selectedNumbers.Count < pairCount)
        {
            //availableNumbers���� ���õ� ��ȣ�� �����ؼ� �ߺ��� �����Ѵ�.
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