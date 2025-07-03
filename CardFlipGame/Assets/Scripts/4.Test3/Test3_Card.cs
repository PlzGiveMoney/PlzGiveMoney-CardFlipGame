using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Test3_Card : MonoBehaviour
{
    public int idx = 0;

    public GameObject front;
    public GameObject back;

    public Animator anim;

    public SpriteRenderer frontImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setting(int number)
    {
        idx = number;
        frontImage.sprite = Resources.Load<Sprite>($"4.Test3/Resources/rtan{idx}");
    }

    public void OpenCard()
    { 
        anim.SetBool("isOpen",true);
        front.SetActive(true);
        back.SetActive(false);

        //first가 비었다면,
        if(Test3_GameManager.Instance.firstCard == null)
        {
            Test3_GameManager.Instance.firstCard = this;
        }
        else
        {
            Test3_GameManager.Instance.secondCard = this;
            Test3_GameManager.Instance.Matched();
        }
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
