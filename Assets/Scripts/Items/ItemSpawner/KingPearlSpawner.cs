using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class KingPearlSpawner : ItemSpawner
{
    public Transform[] kingPearlSpawnPoints1;
    public Transform[] kingPearlSpawnPoints2;
    public float startSpawnKingPearlTime = 10f;
    public float increaseSpawnKingPearlTime = 35f;
    //private Vector2[] spawnPositions;
    public GameObject item; // ������ �����۵�
    private void Start()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();
    }
    private void Update()
    {
        if (Managers.Game.GameState != EGameState.Playing)
            return;
        // ���� ������ ������ ���� �������� ���� �ֱ� �̻� ����
        // && �÷��̾� ĳ���Ͱ� ������
        // if (Ÿ�̸��� �ð��� �ش� ���� �ð����� ������ ��)
        // startSpawnHourGlassTime
        if (Time.time >= lastSpawnTime + timeBetSpawn && Managers.Item.KingPearl == 0 /*&& playerTransform != null*/)
        {
            // ������ ���� �ð� ����
            lastSpawnTime = Time.time;
            // ���� �ֱ⸦ �������� ����
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
            // ������ ���� ����

            if (Scene != null && 60 - Scene.GameTimer > startSpawnKingPearlTime)
                Spawn();
            
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

        if (Scene != null && 60 - Scene.GameTimer < increaseSpawnKingPearlTime)
        {
            foreach (Transform spawnPoint in kingPearlSpawnPoints1)
            {
                //Instantiate(item, spawnPoint.position, spawnPoint.rotation);
                Managers.Resource.InstantiateItem("Item/KingPearl/KingPearl", spawnPoint.position, spawnPoint.rotation);
            }
            Managers.Item.KingPearl = kingPearlSpawnPoints1.Length;
        }
        else
        {
            foreach (Transform spawnPoint in kingPearlSpawnPoints2)
            {
                //Instantiate(item, spawnPoint.position, spawnPoint.rotation);
                Managers.Resource.InstantiateItem("Item/KingPearl/KingPearl", spawnPoint.position, spawnPoint.rotation);
            }
            Managers.Item.KingPearl = kingPearlSpawnPoints2.Length;
        }
        

    }
}
