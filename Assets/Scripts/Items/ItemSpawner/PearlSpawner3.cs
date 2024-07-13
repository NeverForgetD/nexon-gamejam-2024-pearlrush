using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearlSpawner3 : ItemSpawner
{
    public float startPearl3 = 40f;
    public int numOfPearls = 16;
    public float distanceFromCenterPearl = 1f;
    private  bool showOnce = false;

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

        if (Scene != null && (60f - Scene.GameTimer) > startPearl3 && !showOnce)
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

        //Vector2 center = GetRandomPointInBox();
        Vector2 center = Vector2.zero;

        float angleIncrement = 360f / numOfPearls;

        for (int i = 0; i < numOfPearls; i++)
        {
            // ������ �������� ��ȯ
            float angleInRadians = (i * angleIncrement) * Mathf.Deg2Rad;

            // ���ο� ��ǥ ���
            Vector2 newPoint = new Vector2(
                center.x + distanceFromCenterPearl * Mathf.Cos(angleInRadians),
                center.y + distanceFromCenterPearl * Mathf.Sin(angleInRadians)
            );

            //GameObject bomb = Instantiate(item, newPoint, Quaternion.identity);
            GameObject bomb = Managers.Resource.InstantiateItem("Item/Pearl/Pearl", newPoint, Quaternion.identity);
            showOnce = true;
        }
    }
}
