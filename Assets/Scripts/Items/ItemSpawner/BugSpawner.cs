using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : ItemSpawner
{

    public float startSpawnBugTime;
 
    public GameObject item; // 생성할 아이템들
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
        // 현재 시점이 마지막 생성 시점에서 생성 주기 이상 지남
        // && 플레이어 캐릭터가 존재함
        // if (타이머의 시간이 해당 제한 시간보다 지났을 떄)
        // startSpawnHourGlassTime
        
        if (Scene != null && (60f - Scene.GameTimer) > startSpawnBugTime)
        {
            if (Time.time >= lastSpawnTime + timeBetSpawn/*&& playerTransform != null*/)
            {
                // 마지막 생성 시간 갱신
                lastSpawnTime = Time.time;
                // 생성 주기를 랜덤으로 변경
                timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
                // 아이템 생성 실행
                Spawn();
            }
        }
    }

    protected override void Spawn()
    {
        //if ()

        Vector2 spawnPosition =
            GetRandomPointInBox();

        // 바닥에서 0.5만큼 위로 올리기
        // spawnPosition += Vector3.up * 0.5f;

        // 아이템 중 하나를 무작위로 골라 랜덤 위치에 생성
        //GameObject selectedItem = items[Random.Range(0, items.Length)];


        //GameObject bug = Instantiate(item, spawnPosition, Quaternion.identity);
        GameObject bug = Managers.Resource.InstantiateItem("Item/Bug/Bug", spawnPosition, Quaternion.identity);

    }
}
