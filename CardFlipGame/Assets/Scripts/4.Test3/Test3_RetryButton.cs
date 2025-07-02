using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test3_RetryButton : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("TestScene3");
    }
}
