using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourGlassSpawner : ItemSpawner
{
    public float startSpawnHourGlassTime;
    public float minDistance = 2f; // �÷��̾� ��ġ�κ��� �������� ��ġ�� �ּ� �ݰ�
    public GameObject[] items; // ������ �����۵�

    private void Update()
    {
        // ���� ������ ������ ���� �������� ���� �ֱ� �̻� ����
        // && �÷��̾� ĳ���Ͱ� ������
        // if (Ÿ�̸��� �ð��� �ش� ���� �ð����� ������ ��)
        // startSpawnHourGlassTime
        var gameScene = Managers.Scene.CurrentScene as GameScene;
        if (gameScene != null && (60f - gameScene.GameTimer) > startSpawnHourGlassTime)
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
            Managers.Resource.Instantiate("Item/HourGlassPlus/HourGlassMinus", spawnPosition, Quaternion.identity);
        }
        else
        {
            selectedItem = items[1];
            Managers.Resource.Instantiate("Item/HourGlassPlus/HourGlassPlus", spawnPosition, Quaternion.identity);
        }

        //GameObject hourGlass = Instantiate(selectedItem, spawnPosition, Quaternion.identity);

    }
}
