using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI; // �߰�

public class GameManager : MonoBehaviour
{
    public GameState gameState = GameState.Start;

    void Start()
    {
        Singleton.Instance.InitGame();
    }

    //public IEnumerator OpenPicture()
    //{
    //    gameState = GameState.End;
    //    backGround.SetActive(true);
    //    backSprite = backGround.GetComponent<SpriteRenderer>();
    //    for (int i = 0; i < backSpriteSO.sprites.Count; i++)
    //    {
    //        backSprite.sprite = backSpriteSO.sprites[i];
    //        Debug.Log("��� ��������Ʈ ����: " + backSprite.sprite.name);
    //        yield return new WaitForSeconds(0.1f); // ī�� ���� ����
    //    }
    //    Time.timeScale = 0.0f;
    //}
}
