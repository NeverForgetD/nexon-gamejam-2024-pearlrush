using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager
{
    public int counter { get; set; }

    /*
    private void Start() // ���߿� ���� ���� �ϴ� �������� ����
    {
        startTime = Time.time;
    }

    // ���� �� �� startTime + endTime

    private void Update()
    {
        currentTime = startTime + endTime - Time.time;

        Debug.Log((int)currentTime);
    }

    public void Clear()
    {
        // �ð� �ʱ�ȭ
    }


    */
    public void Clear()
    {
        counter = 60;
    }
}
