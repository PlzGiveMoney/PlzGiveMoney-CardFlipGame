using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test1_UIManager : MonoBehaviour
{
    public GameObject OptionUI;


    public void OnOptionButton()
    {
        Test1_GameManager.Instance.gameState = Test1_GameManager.GameState.Option;
        OptionUI.SetActive(true);
    }

    public void OnOptionCloseButton()
    {
        Test1_GameManager.Instance.gameState = Test1_GameManager.GameState.Playing;
        OptionUI.SetActive(false);
    }

    public void OnMainButton()
    {
        //SceneManager.LoadScene("MainScean");
        Debug.Log("Main Button Clicked");
    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene("TestScene1");
    }
}
