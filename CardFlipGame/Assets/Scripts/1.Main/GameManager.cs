using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState gameState = GameState.Start;

    public void setGame()
    {
        Singleton.Instance.InitGameDatas(); // 게임 데이터 초기화

        gameState = GameState.Playing;

        Singleton.Instance.Stage += 1; // 스테이지 증가
        StartCoroutine(Singleton.Instance.boardScript.CreateCard(Singleton.Instance.Stage));
    }
}
