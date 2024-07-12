using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingPearlSpawner : ItemSpawner
{
    public Transform[] kingPearlSpawnPoints;
    public float startSpawnKingPearlTime;
    //private Vector2[] spawnPositions;
    public GameObject item; // ������ �����۵�
    
    private void Update()
    {
        // ���� ������ ������ ���� �������� ���� �ֱ� �̻� ����
        // && �÷��̾� ĳ���Ͱ� ������
        // if (Ÿ�̸��� �ð��� �ش� ���� �ð����� ������ ��)
        // startSpawnHourGlassTime
        if (Time.time >= lastSpawnTime + timeBetSpawn && Managers.Item.KingPear == 0 /*&& playerTransform != null*/)
        {
            // ������ ���� �ð� ����
            lastSpawnTime = Time.time;
            // ���� �ֱ⸦ �������� ����
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
            // ������ ���� ����
            Spawn();
            Managers.Item.KingPear = kingPearlSpawnPoints.Length;
        }
    }

    protected override void Spawn()
    {
        /*
        spawnPositions = null;
        for (int i = 0; i < kingPearlSpawnPoints.Length; i++)
        {
            spawnPositions[i] = kingPearlSpawnPoints[i].transform.position;
        }
        */

        // �ٴڿ��� 0.5��ŭ ���� �ø���
        // spawnPosition += Vector3.up * 0.5f;

        // ������ �� �ϳ��� �������� ��� ���� ��ġ�� ����
        //GameObject selectedItem = items[Random.Range(0, items.Length)];
        
        /*
        for (int i = 0; i < kingPearlSpawnPoints.Length; i++)
        {
            Debug.Log(kingPearlSpawnPoints[i]);
            GameObject kingPearl = Instantiate(selectedItem, kingPearlSpawnPoints[i].position, Quaternion.identity);
        }*/
        foreach (Transform spawnPoint in kingPearlSpawnPoints)
        {
            Instantiate(item, spawnPoint.position, spawnPoint.rotation);
        }

    }
}
