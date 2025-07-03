using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Ãß°¡
using DG.Tweening;

public class Test1_Card : MonoBehaviour
{
    public int index = 0;
    public SpriteRenderer frontImage;
    public GameObject front;
    public GameObject back;
    public Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void OpenCard()
    {
        if(Test1_GameManager.Instance.gameState != Test1_GameManager.GameState.Playing) return;
        Test1_SoundControl.Instance.cardFlipSFXPlay();

        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);

        if (Test1_GameManager.Instance.firstCard == null)
        {
            Test1_GameManager.Instance.firstCard = this;
        }
        else if(Test1_GameManager.Instance.secondCard == null)
        {
            Test1_GameManager.Instance.secondCard = this;
            Test1_GameManager.Instance.isMatched();
        }
    }
    /*
    public void Setting(int idx)
    {
        index = idx;
        string rtanName = $"package/Images_1/jinwoo{index}";
        frontImage = transform.Find("Front").GetComponent<SpriteRenderer>();
        frontImage.sprite = Resources.Load<Sprite>(rtanName);
    }
    */
    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 1.0f);
    }

    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }

   public void CloseCard()
   {
        Invoke("CloseCardInvoke", 1.0f);
   }

    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }

}