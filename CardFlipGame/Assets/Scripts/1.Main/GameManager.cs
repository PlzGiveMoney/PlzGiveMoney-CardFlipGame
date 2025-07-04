using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState gameState = GameState.Start;

    public void setGame()
    {
        gameState = GameState.Playing;

        Singleton.Instance.InitGameDatas(); // ���� ������ �ʱ�ȭ
        Singleton.Instance.Stage += 1; // �������� ����
        StartCoroutine(Singleton.Instance.boardScript.CreateCard(Singleton.Instance.Stage));
    }
}
