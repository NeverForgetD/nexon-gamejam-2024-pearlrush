using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : ItemSpawner
{

    public float startSpawnBugTime;
 
    public GameObject item; // ������ �����۵�

    private void Update()
    {
        // ���� ������ ������ ���� �������� ���� �ֱ� �̻� ����
        // && �÷��̾� ĳ���Ͱ� ������
        // if (Ÿ�̸��� �ð��� �ش� ���� �ð����� ������ ��)
        // startSpawnHourGlassTime
        var gameScene = Managers.Scene.CurrentScene as GameScene;
        if (gameScene != null && (60f - gameScene.GameTimer) > startSpawnBugTime)
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

        Vector2 spawnPosition =
            GetRandomPointInBox();

        // �ٴڿ��� 0.5��ŭ ���� �ø���
        // spawnPosition += Vector3.up * 0.5f;

        // ������ �� �ϳ��� �������� ��� ���� ��ġ�� ����
        //GameObject selectedItem = items[Random.Range(0, items.Length)];


        //GameObject bug = Instantiate(item, spawnPosition, Quaternion.identity);
        GameObject bug = Managers.Resource.Instantiate("Item/Bug/Bug", spawnPosition, Quaternion.identity);
        Debug.Log("�٤ä�������");

    }
}
