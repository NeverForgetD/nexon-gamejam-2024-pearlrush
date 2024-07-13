using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BombSpawner : ItemSpawner
{
    public float startSpawnBombTime;
    public float maxDistance = 5f; // �÷��̾� ��ġ�κ��� �������� ��ġ�� �ִ� �ݰ�
    public GameObject item; // ������ �����۵�


    public float distanceFromCenterBomb = 1f;
    private int numberOfPoints = 3; //2~4


    private void Update()
    {
        // ���� ������ ������ ���� �������� ���� �ֱ� �̻� ����
        // && �÷��̾� ĳ���Ͱ� ������
        // if (Ÿ�̸��� �ð��� �ش� ���� �ð����� ������ ��)
        // startSpawnHourGlassTime
        var gameScene = Managers.Scene.CurrentScene as GameScene;
        if (gameScene != null && (60f - gameScene.GameTimer) > startSpawnBombTime)
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

        numberOfPoints = Mathf.Clamp(numberOfPoints, 2, 4);
        float angleIncrement = 360f / numberOfPoints;

        for (int i = 0; i < numberOfPoints; i++)
        {
            // ������ �������� ��ȯ
            float angleInRadians = (i * angleIncrement) * Mathf.Deg2Rad;

            // ���ο� ��ǥ ���
            Vector2 newPoint = new Vector2(
                spawnPosition.x + distanceFromCenterBomb * Mathf.Cos(angleInRadians),
                spawnPosition.y + distanceFromCenterBomb * Mathf.Sin(angleInRadians)
            );

            GameObject bomb = Instantiate(item, newPoint, Quaternion.identity);
            // ���⿡ ��/�� ������� ���
            
        }

        // �ٴڿ��� 0.5��ŭ ���� �ø���
        // spawnPosition += Vector3.up * 0.5f;

        // ������ �� �ϳ��� �������� ��� ���� ��ġ�� ����
        //GameObject selectedItem = items[Random.Range(0, items.Length)];



    }
}
