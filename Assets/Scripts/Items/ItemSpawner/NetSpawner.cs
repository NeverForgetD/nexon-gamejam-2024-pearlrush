using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NetSpawner : ItemSpawner
{
    public float maxDistance = 5f; // �÷��̾� ��ġ�κ��� �������� ��ġ�� �ִ� �ݰ�
    public GameObject item; // ������ ������
    public int gapBetPlayerScore = 10;
    public int timeBetNetSpawn = 10;
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
        if (Mathf.Abs(Managers.Score.player1Score - Managers.Score.player2Score) > gapBetPlayerScore)
        {
            if (!Managers.Item.netHasBeenSpawned)
                Spawn();
            else
            {
                if (Scene != null && (60f - Scene.GameTimer) > Managers.Item.netSpawnedTime + timeBetNetSpawn)
                    Spawn();
            }
        }
    }

    protected override void Spawn()
    {
        //if ()
        if (Managers.Score.player1Score < Managers.Score.player2Score)
            playerTransform = GameObject.FindGameObjectWithTag("Player1").transform;
        else
            playerTransform = GameObject.FindGameObjectWithTag("Player2").transform;
        Vector2 spawnPosition =
            GetRandomPointInRange(playerTransform.position, maxDistance);

        // �ٴڿ��� 0.5��ŭ ���� �ø���
        // spawnPosition += Vector3.up * 0.5f;

        // ������ �� �ϳ��� �������� ��� ���� ��ġ�� ����
        //GameObject selectedItem = items[Random.Range(0, items.Length)];



        //GameObject net = Instantiate(item, spawnPosition, Quaternion.identity);
        GameObject net = Managers.Resource.Instantiate("Item/Net/net", spawnPosition, Quaternion.identity);

        Managers.Item.netHasBeenSpawned = true;
        Managers.Item.netSpawnedTime = 60f - Scene.GameTimer;

    }
}
