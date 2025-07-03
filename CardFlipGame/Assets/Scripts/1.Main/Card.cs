using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Ãß°¡
using DG.Tweening;

public class Card : MonoBehaviour
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
        Singleton.Instance.soundManager.cardFlipSFXPlay();

        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);


    }

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