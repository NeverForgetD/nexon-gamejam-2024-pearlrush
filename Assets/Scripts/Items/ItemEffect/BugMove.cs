using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMove : MonoBehaviour
{
    public float moveSpeed = 2f;  // �̵� �ӵ�
    public float minX = -6f;      // �̵� ���� �ּ� x ��
    public float maxX = 6f;       // �̵� ���� �ִ� x ��
    private float moveDirection = 1;


    void Update()
    {
        float moveX = moveSpeed * Time.deltaTime * moveDirection;
        transform.position = new Vector2(transform.position.x + moveX, transform.position.y);
        if (Mathf.Abs(transform.position.x) > maxX)
        {
            transform.position = new Vector2(maxX*moveDirection, transform.position.y);
            moveDirection = -moveDirection;
        }
    }


}
