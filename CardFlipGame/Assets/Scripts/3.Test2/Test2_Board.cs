//using DG.Tweening;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using Unity.Burst.Intrinsics;
//using UnityEngine;

//public class Test2_Board : MonoBehaviour
//{
//    //���� �����ִ� ī�� ī��Ʈ
//    public int currentCardCount = 0;

//    public Test2_Card card;

//    //��û�� ��ġ�� ���� ��ġ�Ѵ�
//    public IEnumerator CreateCard()
//    {
//        //pairCount��ŭ �����ϰ� �̱� (�ߺ� X)
//        List<int> selectedNumbers = new List<int>();
//        while (selectedNumbers.Count < pairCount)
//        {
//            //availableNumbers���� ���õ� ��ȣ�� �����ؼ� �ߺ��� �����Ѵ�.
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

//        //Debug.Log("�迭 Ȯ�ο�" + string.Join(", ", arr));

//        for (int i = 0; i < stageInCard; i++)
//        {
//            // ī�� ����
//            GameObject go = Instantiate(card);
//            go.transform.position = new Vector2(0, -5f);
//            // ī�� ���� ���� ���
//            Test1_SoundControl.Instance.creadtCardSFXPlay(); // ī�� ���� ���� ���
//            // ī�� ��������Ʈ �Է�
//            Transform front = go.transform.Find("Front");
//            SpriteRenderer sr = front.GetComponent<SpriteRenderer>();
//            sr.sprite = spriteListSO.sprites[arr[i]];
//            // ī�� ��ġ ���� �� �̵�
//            float x = (i % 4) * 1.4f - 2.1f;
//            float y = (i / 4) * 1.4f - 3.0f;
//            Vector2 targetPos = new Vector2(x, y);
//            go.transform.DOMove(targetPos, 0.3f).SetEase(Ease.OutQuad);
//            //index��, ������Ʈ �Է�
//            Test1_GameManager.Instance.cardCount = arr.Length;
//            var cardComp = go.GetComponent<Test1_Card>();
//            cardComp.index = arr[i];
//            yield return new WaitForSeconds(0.1f); // ī�� ���� ����
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
//                //UI Manager ȣ��
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
