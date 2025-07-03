using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI; // 추가

public class GameManager : MonoBehaviour
{
    public GameState gameState = GameState.Start;

    public void setGame()
    {
        gameState = GameState.Playing;

        Singleton.Instance.Stage += 1; // 스테이지 증가
        StartCoroutine(Singleton.Instance.boardScript.CreateCard(Singleton.Instance.Stage));
    }

    //public IEnumerator OpenPicture()
    //{
    //    gameState = GameState.End;
    //    backGround.SetActive(true);
    //    backSprite = backGround.GetComponent<SpriteRenderer>();
    //    for (int i = 0; i < backSpriteSO.sprites.Count; i++)
    //    {
    //        backSprite.sprite = backSpriteSO.sprites[i];
    //        Debug.Log("배경 스프라이트 변경: " + backSprite.sprite.name);
    //        yield return new WaitForSeconds(0.1f); // 카드 생성 간격
    //    }
    //    Time.timeScale = 0.0f;
    //}
}
