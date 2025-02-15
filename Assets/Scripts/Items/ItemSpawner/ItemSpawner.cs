using Unity.VisualScripting;
using UnityEngine;

// 주기적으로 아이템을 플레이어 근처에 생성하는 스크립트
public class ItemSpawner : MonoBehaviour
{
    //public GameObject[] items; // 생성할 아이템들
    //public GameObject item;
    public Transform playerTransform; // 플레이어의 트랜스폼

    //public float minDistance = 2f; // 플레이어 위치로부터 아이템이 배치될 최소 반경
    //public float maxDistance = 5f; // 플레이어 위치로부터 아이템이 배치될 최대 반경


    public float timeBetSpawnMax = 7f; // 최대 시간 간격
    public float timeBetSpawnMin = 2f; // 최소 시간 간격
    public float timeBetSpawn; // 생성 간격
    // 지금은 생성 간격이 매번 다르게 설정

    public float lastSpawnTime; // 마지막 생성 시점

    private Vector3 randomVectorPos;

    // 맵 안에서만 생성될 수 있도록 나중에 하드코딩
    /*
    public Vector3 baseVertex1;
    public Vector3 baseVertex2;
    public Vector3 baseVertex3;
    public Vector3 baseVertex4;
    */
    public float baseX1 = -6.7f;
    public float baseX2 = 6.7f;
    public float baseY1 = -3.8f;
    public float baseY2 = 3.8f;

    [SerializeField] private int _recommendedPlayerIndex = 0;
    public int RecommendedPlayerIndex { get => _recommendedPlayerIndex; set => _recommendedPlayerIndex = value; }

    [SerializeField] private GameScene _scene;
    public GameScene Scene { get => _scene; private set => _scene = value; }

    private void Start()
    {
    }

    protected virtual void Init()
    {
        Scene = Managers.Scene.CurrentScene as GameScene;
    }

    private void Update()
    {
        
    }
   

    // 실제 아이템 생성 처리
    
    protected virtual void Spawn()
    {
        /*
        // 플레이어 근처에서 내비메시 위의 랜덤 위치 가져오기
        Vector3 spawnPosition =
            GetRandomPoint(playerTransform.position, maxDistance);
        // 바닥에서 0.5만큼 위로 올리기
        spawnPosition += Vector3.up * 0.5f;

        // 아이템 중 하나를 무작위로 골라 랜덤 위치에 생성
        //GameObject selectedItem = items[Random.Range(0, items.Length)]; // 이 부분 다시 
        GameObject selectedItem = SelectRandomItem();
        
        
        GameObject item = Instantiate(selectedItem, spawnPosition, Quaternion.identity);

        // 생성된 아이템을 5초 뒤에 파괴
        // Destroy(item, 5f);
        // 해도 되고 안 해도 되고
        */
    }

    // 내비메시 위의 랜덤한 위치를 반환하는 메서드
    // center를 중심으로 distance 반경 안에서 랜덤한 위치를 찾는다
    public Vector2 GetRandomPointOutRange(Vector2 center, float distance) //max distance *1.5f
    {
        // center를 중심으로 반지름이 maxDistance인 구 안에서의 랜덤한 위치 하나를 저장
        // Random.insideUnitSphere는 반지름이 1인 구 안에서의 랜덤한 한 점을 반환하는 프로퍼티
        do
        {
            float randomAngle = Random.Range(0f, Mathf.PI * 2f); // 0~360도 사이 하나의 각도
            float randomDistance = Random.Range(distance, distance * 1.5f);

            float x = center.x + Mathf.Cos(randomAngle) * distance;
            float y = center.y + Mathf.Sin(randomAngle) * distance;

            randomVectorPos = new Vector2(x, y);

        } while (IsInsideBase(randomVectorPos));
        Vector2 vectorPos = randomVectorPos;
        // 찾은 점 반환
        return vectorPos;
    }

    public Vector2 GetRandomPointInRange(Vector2 center, float distance) // min distance 1f
    {
        // center를 중심으로 반지름이 maxDistance인 구 안에서의 랜덤한 위치 하나를 저장
        // Random.insideUnitSphere는 반지름이 1인 구 안에서의 랜덤한 한 점을 반환하는 프로퍼티
        do
        {
            float randomAngle = Random.Range(0f, Mathf.PI * 2f); // 0~360도 사이 하나의 각도
            float randomDistance = Random.Range(1f, distance);

            float x = center.x + Mathf.Cos(randomAngle) * distance;
            float y = center.y + Mathf.Sin(randomAngle) * distance;

            randomVectorPos = new Vector2(x, y);

        } while (IsInsideBase(randomVectorPos));
        Vector2 vectorPos = randomVectorPos;
        // 찾은 점 반환
        return vectorPos;
    }

    public Vector2 GetRandomPointInBox()
    {
        float x = Random.Range(baseX1, baseX2);
        float y = Random.Range(baseY1, baseY2);

        Vector2 vectorPos = new Vector2(x, y);
        return vectorPos;
    }

    public Vector2 GetRandomPointInBoxForPearl()
    {

        float x = Random.Range(-3.5f, 3.5f);
        float y = Random.Range(-1.5f, 1.5f);

        Vector2 vectorPos = new Vector2(x, y);
        return vectorPos;
    }
    public GameObject SelectRandomItem(GameObject[] itemlist)
    {
        // Time

        GameObject selectedItem = itemlist[Random.Range(0, itemlist.Length)]; // 이 부분 다시  
        return gameObject;
    }

    public bool IsInsideBase(Vector3 itemVector)
    {
        if ((itemVector.x < baseX2 && itemVector.x < baseX1) && (itemVector.y < baseY2 && itemVector.y < baseY1))
            return true;
        else
            return false;
    }
    



}
