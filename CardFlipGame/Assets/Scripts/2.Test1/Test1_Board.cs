//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.Linq;
//using DG.Tweening;

public class Test1_Board : MonoBehaviour
{
    public GameObject card;
    public SpriteListSO spriteListSO;
    public int stageInCard = 16;//�ӽ������� ���� ���̵� ��½� �����ϱ�
    int pairCount;
    public int cardCount;//���� ����
    //public static Text1_Board Instance; ����� �̱������� ���ϴ°� ������

//    private void Awake()
//    {/*
//         if (Instance == null)
//        {
//            Instance = this;
//        }*/
//    }


//    void Start()
//    {

//    }

    public IEnumerator CreateCard()
    {
        //sprite�� ������ ������ �� ���� ���ڸ� �����ϰ� ī���� ������ŭ �̾Ƽ� index�� ������ �迭�� �ִ´�.�ε� �����ϰ� �� ����� ������?
        cardCount = spriteListSO.sprites.Count; 
        pairCount = stageInCard/2;// �� ����

        //sprite �ε����� ��밡���� ���� ����Ʈ ����
        List<int> availableNumbers = new List<int>();
        for (int i = 0; i < cardCount; i++)
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

//        int[] arr = new int[pairCount * 2];
//        for (int i = 0; i < pairCount; i++)
//        {
//            arr[i * 2] = selectedNumbers[i];
//            arr[i * 2 + 1] = selectedNumbers[i];
//        }
//        arr = arr.OrderBy(x => Random.Range(0f, 1f)).ToArray();

        //Debug.Log("�迭 Ȯ�ο�" + string.Join(", ", arr));

        for (int i = 0; i < stageInCard; i++)
        {
            // ī�� ����
            GameObject go = Instantiate(card);
            go.transform.position = new Vector2(0, -5f);
            // ī�� ���� ���� ���
            Test1_SoundControl.Instance.creadtCardSFXPlay(); // ī�� ���� ���� ���
            // ī�� ��������Ʈ �Է�
            Transform front = go.transform.Find("Front");
            SpriteRenderer sr = front.GetComponent<SpriteRenderer>();
            sr.sprite = spriteListSO.sprites[arr[i]];
            // ī�� ��ġ ���� �� �̵�
            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f - 3.0f;
            Vector2 targetPos = new Vector2(x, y);
            go.transform.DOMove(targetPos, 0.3f).SetEase(Ease.OutQuad);
            //index��, ������Ʈ �Է�
            Test1_GameManager.Instance.cardCount = arr.Length;
            var cardComp = go.GetComponent<Test1_Card>();
            cardComp.index = arr[i];
            yield return new WaitForSeconds(0.1f); // ī�� ���� ����
        }
        Test1_GameManager.Instance.gameState = Test1_GameManager.GameState.Playing;

//    }

//}