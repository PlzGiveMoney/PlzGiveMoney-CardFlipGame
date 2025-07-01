using UnityEngine;

public class Card : MonoBehaviour
{
    public int index = 0;

    public SpriteRenderer frontImage;

    public GameObject front;

    public GameObject back;

    public Animator anim;

    public void OpenCard()
    {
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);

        if (Test2_GameManager.Instance.firstCard == null)
        {
            Test2_GameManager.Instance.firstCard = this;
        }
        else
        {
            Test2_GameManager.Instance.secondCard = this;
            Test2_GameManager.Instance.checkMatched();
        }
    }

    public void Setting(int number)
    {
        index = number;
        frontImage.sprite = Resources.Load<Sprite>($"package/Images/rtan{index}");
    }
    public void DestroyCard()
    {
        Invoke("DestoryCardInvoke", 0.5f);
    }

    void DestoryCardInvoke()
    {
        Destroy(gameObject);
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 0.5f);
    }

    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }
}