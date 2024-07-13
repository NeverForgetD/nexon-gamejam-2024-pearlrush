using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourGlassSpawner : ItemSpawner
{
    public float startSpawnHourGlassTime;
    public float minDistance = 2f; // �÷��̾� ��ġ�κ��� �������� ��ġ�� �ּ� �ݰ�
    public GameObject[] items; // ������ �����۵�
    public float lastTimeSpawn = 7f;
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

        if (Scene != null && (60f - Scene.GameTimer) > startSpawnHourGlassTime && Scene.GameTimer > lastTimeSpawn)
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
            GetRandomPointOutRange(playerTransform.position, minDistance);

        // �ٴڿ��� 0.5��ŭ ���� �ø���
        // spawnPosition += Vector3.up * 0.5f;

        // ������ �� �ϳ��� �������� ��� ���� ��ġ�� ����
        //GameObject selectedItem = items[Random.Range(0, items.Length)];
        GameObject selectedItem;
        int choice = Random.Range(0, 2);
        if (choice == 0)
        {
            selectedItem = items[0];
            Managers.Resource.InstantiateItem("Item/HourGlassPlus/HourGlassMinus", spawnPosition, Quaternion.identity);
        }
        else
        {
            selectedItem = items[1];
            Managers.Resource.InstantiateItem("Item/HourGlassPlus/HourGlassPlus", spawnPosition, Quaternion.identity);
        }

        //GameObject hourGlass = Instantiate(selectedItem, spawnPosition, Quaternion.identity);

    }
}
