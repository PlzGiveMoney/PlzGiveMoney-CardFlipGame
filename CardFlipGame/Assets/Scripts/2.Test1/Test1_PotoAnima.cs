using System.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Test1_PotoAnima : MonoBehaviour
{
    public  Vector3 targetScale = new Vector3(4.23f, 4.23f, 1f); // 최종 크기
    public float growDuration = 1f;
    public float shakeAngle = 4f;
    public float shakeSpeed = 2f;

    private bool isShaking = false;
    private Quaternion originalRotation;

    void Start()
    {
        originalRotation = transform.rotation;

        // 시작 스케일을 작게 설정
        transform.localScale = new Vector3(0.5f, 0.5f, 1f);

        StartCoroutine(GrowThenShake());
    }

    IEnumerator GrowThenShake()
    {
        Vector3 startScale = transform.localScale;
        float timer = 0f;

        while (timer < growDuration)
        {
            transform.localScale = Vector3.Lerp(startScale, targetScale, timer / growDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
        isShaking = true;
    }

    void Update()
    {
        if (isShaking)
        {
            float angle = Mathf.Sin(Time.time * shakeSpeed) * shakeAngle;
            transform.rotation = originalRotation * Quaternion.Euler(0f, 0f, angle);
        }
    }
}