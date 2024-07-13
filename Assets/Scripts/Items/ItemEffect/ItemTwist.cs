using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTwist : MonoBehaviour
{
    public float rotationSpeed = 500f;   // ȸ�� �ӵ� (����/��)
    public float rotationRange = 30f;   // ȸ�� ���� (�¿� �ִ� ȸ�� ����)

    private float startRotation;

    void Start()
    {
        startRotation = transform.rotation.eulerAngles.z;  // ���� �� ȸ�� ���� ����
    }

    void Update()
    {
        // Mathf.Sin �Լ��� ����Ͽ� ȸ�� ���� ���
        float angle = startRotation + rotationRange * Mathf.Sin(Time.time * rotationSpeed * Mathf.Deg2Rad);

        // ȸ�� ������ �����Ͽ� ��ü ȸ��
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
