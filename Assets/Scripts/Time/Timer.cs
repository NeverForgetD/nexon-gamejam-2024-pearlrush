using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // public Text counterText; // UI �ؽ�Ʈ ������Ʈ

    void Start()
    {
        // �ڷ�ƾ ����
        StartCoroutine(StartCounter());
    }

    // �ڷ�ƾ ����
    IEnumerator StartCounter()
    {
        while (true)
        {
            Managers.Time.counter--; // ī���� �� ����
            // counterText.text = counter; // UI �ؽ�Ʈ ������Ʈ
            Debug.Log(Managers.Time.counter);

            yield return new WaitForSeconds(1f); // 1�� ����
        }
    }
}
