using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourGlassSpawner : ItemSpawner
{
    public float startSpawnHourGlassTime;
    public float minDistance = 2f; // �÷��̾� ��ġ�κ��� �������� ��ġ�� �ּ� �ݰ�
    public GameObject item; // ������ �����۵�

    private void Update()
    {
        // ���� ������ ������ ���� �������� ���� �ֱ� �̻� ����
        // && �÷��̾� ĳ���Ͱ� ������
        // if (Ÿ�̸��� �ð��� �ش� ���� �ð����� ������ ��)
        // startSpawnHourGlassTime
        if (Time.time >= lastSpawnTime + timeBetSpawn && playerTransform != null)
        {
            // ������ ���� �ð� ����
            lastSpawnTime = Time.time;
            // ���� �ֱ⸦ �������� ����
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
            // ������ ���� ����
            Spawn();
        }
    }

    protected override void Spawn()
    {
        //if ()
        Vector3 spawnPosition =
            GetRandomPointOutRange(playerTransform.position, minDistance);

        // �ٴڿ��� 0.5��ŭ ���� �ø���
        // spawnPosition += Vector3.up * 0.5f;

        // ������ �� �ϳ��� �������� ��� ���� ��ġ�� ����
        //GameObject selectedItem = items[Random.Range(0, items.Length)];
        GameObject selectedItem = item;


        GameObject hourGlass = Instantiate(selectedItem, spawnPosition, Quaternion.identity);

    }
}
