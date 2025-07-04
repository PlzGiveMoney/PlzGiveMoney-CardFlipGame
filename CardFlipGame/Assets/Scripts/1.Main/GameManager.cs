using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState gameState = GameState.Start;

    public void setGame()
    {
        Singleton.Instance.InitGameDatas(); // ���� ������ �ʱ�ȭ

        gameState = GameState.Playing;

        Singleton.Instance.Stage += 1; // �������� ����
        StartCoroutine(Singleton.Instance.boardScript.CreateCard(Singleton.Instance.Stage));
    }
}
