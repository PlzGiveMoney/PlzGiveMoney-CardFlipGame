using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //���� �ð��� ������ �ؽ�Ʈ
    public Text timeTxt;

    //������ ������ �� ������ �г�
    public GameObject endPanel;

    // Update is called once per frame
    void Update()
    {
        Singleton.Instance.curruntTime -= Time.deltaTime;
        timeTxt.text = Singleton.Instance.curruntTime.ToString("N2");
        IsTimeOver();
    }

    public void IsTimeOver()
    {
        if (Singleton.Instance.curruntTime < 10.0f)
        {
            Singleton.Instance.soundManager.audioSource.pitch = 2f;
        }
        //������ ����� �Ŀ� �����ؼ� ������ �� ������ ���� 0���� ���ߵ��� ����
        if (Singleton.Instance.curruntTime < Singleton.Instance.limitTime)
        {
            Singleton.Instance.soundManager.stageFailSFXPlay();
            endPanel.SetActive(true);
            Time.timeScale = 0.0f;
            Singleton.Instance.curruntTime = 0;
        }
    }
}
