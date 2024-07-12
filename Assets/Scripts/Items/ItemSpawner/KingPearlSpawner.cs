using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingPearlSpawner : ItemSpawner
{
    public GameObject[] kingPearlSpawnPoints;
    public float startSpawnKingPearlTime;
    private Vector3[] spawnPositions;
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
        spawnPositions = null;
        for (int i = 0; i < kingPearlSpawnPoints.Length; i++)
        {
            spawnPositions[i] = kingPearlSpawnPoints[i].transform.position;
        }

        // �ٴڿ��� 0.5��ŭ ���� �ø���
        // spawnPosition += Vector3.up * 0.5f;

        // ������ �� �ϳ��� �������� ��� ���� ��ġ�� ����
        //GameObject selectedItem = items[Random.Range(0, items.Length)];
        GameObject selectedItem = item;

        for (int i = 0; i < kingPearlSpawnPoints.Length; i++)
        {
            GameObject kingPearl = Instantiate(selectedItem, spawnPositions[i], Quaternion.identity);
        }
    }
}
