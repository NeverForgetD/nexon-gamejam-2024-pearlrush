using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPearlSpawner : ItemSpawner
{
    public float startSpawnBrokenPearlTime;
    public float maxDistance = 5f; // �÷��̾� ��ġ�κ��� �������� ��ġ�� �ִ� �ݰ�
    public GameObject item; // ������ ������
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
        if (playerTransform == null)
            playerTransform = Managers.Game.Players[RecommendedPlayerIndex].transform;
        // ���� ������ ������ ���� �������� ���� �ֱ� �̻� ����
        // && �÷��̾� ĳ���Ͱ� ������
        // if (Ÿ�̸��� �ð��� �ش� ���� �ð����� ������ ��)
        // startSpawnHourGlassTime
     
        if (Scene != null && (60f - Scene.GameTimer) > startSpawnBrokenPearlTime)
        {
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
    }

    protected override void Spawn()
    {
        //if ()
        Vector2 spawnPosition =
            GetRandomPointInRange(playerTransform.position, maxDistance);

        // �ٴڿ��� 0.5��ŭ ���� �ø���
        // spawnPosition += Vector3.up * 0.5f;

        // ������ �� �ϳ��� �������� ��� ���� ��ġ�� ����
        //GameObject selectedItem = items[Random.Range(0, items.Length)];



        //GameObject brokenSpawner = Instantiate(item, spawnPosition, Quaternion.identity);
        GameObject brokenSpawner = Managers.Resource.Instantiate("Item/BrokenPearl/BrookenPearl", spawnPosition, Quaternion.identity);
    }
}
