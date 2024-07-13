using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMove : MonoBehaviour
{
    public float moveSpeed = 2f;  // �̵� �ӵ�
    public float minX = -7f;      // �̵� ���� �ּ� x ��
    public float maxX = 7f;       // �̵� ���� �ִ� x ��

    private float startX;

    void Start()
    {
        // ��ü�� �ʱ� x ��ġ ����
        startX = transform.position.x;
    }

    void Update()
    {
        float newX = Mathf.PingPong(Time.time * moveSpeed, maxX - minX) + minX;

        // ���ο� x ���� ����Ͽ� ��ü ��ġ ����
        transform.position = new Vector2(newX, transform.position.y);
    }


}
