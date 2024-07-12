using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPearlSpawner : ItemSpawner
{
    public float startSpawnBrokenPearlTime;
    public float maxDistance = 5f; // �÷��̾� ��ġ�κ��� �������� ��ġ�� �ִ� �ݰ�
    public GameObject item; // ������ ������

    private void Update()
    {
        // ���� ������ ������ ���� �������� ���� �ֱ� �̻� ����
        // && �÷��̾� ĳ���Ͱ� ������
        // if (Ÿ�̸��� �ð��� �ش� ���� �ð����� ������ ��)
        // startSpawnHourGlassTime
        var gameScene = Managers.Scene.CurrentScene as GameScene;
        if (gameScene != null && (60f - gameScene.GameTimer) > startSpawnBrokenPearlTime)
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
        Vector3 spawnPosition =
            GetRandomPointInRange(playerTransform.position, maxDistance);

        // �ٴڿ��� 0.5��ŭ ���� �ø���
        // spawnPosition += Vector3.up * 0.5f;

        // ������ �� �ϳ��� �������� ��� ���� ��ġ�� ����
        //GameObject selectedItem = items[Random.Range(0, items.Length)];



        GameObject hourGlass = Instantiate(item, spawnPosition, Quaternion.identity);

    }
}
