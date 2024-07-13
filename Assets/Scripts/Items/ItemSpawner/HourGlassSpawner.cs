using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourGlassSpawner : ItemSpawner
{
    public float startSpawnHourGlassTime;
    public float minDistance = 2f; // �÷��̾� ��ġ�κ��� �������� ��ġ�� �ּ� �ݰ�
    public GameObject[] items; // ������ �����۵�
    public float lastTimeSpawn = 7f;

    public Transform playerTransform1;
    public Transform playerTransform2;

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
        
        if (playerTransform1 == null)
            playerTransform1 = Managers.Game.Players[0].transform;
        if (playerTransform2 == null)
            playerTransform2 = Managers.Game.Players[1].transform;
        
        // ���� ������ ������ ���� �������� ���� �ֱ� �̻� ����
        // && �÷��̾� ĳ���Ͱ� ������
        // if (Ÿ�̸��� �ð��� �ش� ���� �ð����� ������ ��)
        // startSpawnHourGlassTime
       
        if (Scene != null && (60f - Scene.GameTimer) > startSpawnHourGlassTime && Scene.GameTimer > lastTimeSpawn)
        {
            if (Time.time >= lastSpawnTime + timeBetSpawn && playerTransform1 != null && playerTransform2 != null)
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

        Vector2 midPosition = new Vector2((playerTransform1.position.x + playerTransform2.position.x) / 2, (playerTransform1.position.y + playerTransform2.position.y) / 2);
        Vector2 spawnPosition = GetRandomPointOutRange(midPosition, minDistance);
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
