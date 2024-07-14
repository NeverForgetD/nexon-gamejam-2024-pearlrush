using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PearlSpawner2 : ItemSpawner
{
    public float startPearl2 = 0f;
    public float endPearl2 = 50f;

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

        if (playerTransform == null)
            playerTransform = Managers.Game.Players[RecommendedPlayerIndex].transform;
        // ���� ������ ������ ���� �������� ���� �ֱ� �̻� ����
        // && �÷��̾� ĳ���Ͱ� ������
        // if (Ÿ�̸��� �ð��� �ش� ���� �ð����� ������ ��)
        // startSpawnHourGlassTime

        if (Scene != null && (60f - Scene.GameTimer) > startPearl2 && (60f - Scene.GameTimer) < endPearl2)
        {
            if (Time.time >= lastSpawnTime + timeBetSpawn/*&& playerTransform != null*/)
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

        Vector2 spawnPosition = GetRandomPointInBox();

        // �ٴڿ��� 0.5��ŭ ���� �ø���
        // spawnPosition += Vector3.up * 0.5f;

        // ������ �� �ϳ��� �������� ��� ���� ��ġ�� ����
        //GameObject selectedItem = items[Random.Range(0, items.Length)];


        //GameObject bug = Instantiate(item, spawnPosition, Quaternion.identity);
        Managers.Resource.InstantiateItem("Item/Pearl/Pearl", spawnPosition, Quaternion.identity);
    }
}
