using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NetSpawner : ItemSpawner
{
    public float maxDistance = 5f; // �÷��̾� ��ġ�κ��� �������� ��ġ�� �ִ� �ݰ�
    public GameObject item; // ������ ������
    public int gapBetPlayerScore = 10;
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
                var gameScene = Managers.Scene.CurrentScene as GameScene;
                if (gameScene != null && (60f - gameScene.GameTimer) > Managers.Item.netSpawnedTime)
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
        var gameScene = Managers.Scene.CurrentScene as GameScene;
        Managers.Item.netSpawnedTime = 60f - gameScene.GameTimer;

    }
}
