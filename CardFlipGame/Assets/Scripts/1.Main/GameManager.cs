using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState gameState = GameState.Start;

    public void setGame()
    {
        gameState = GameState.Playing;

        Singleton.Instance.Stage += 1; // 스테이지 증가

        Singleton.Instance.InitGameDatas();
        StartCoroutine(Singleton.Instance.boardScript.CreateCard(Singleton.Instance.Stage));
    }
}
