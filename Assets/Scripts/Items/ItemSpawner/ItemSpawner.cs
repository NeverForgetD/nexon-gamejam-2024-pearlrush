using Unity.VisualScripting;
using UnityEngine;

// �ֱ������� �������� �÷��̾� ��ó�� �����ϴ� ��ũ��Ʈ
public class ItemSpawner : MonoBehaviour
{
    //public GameObject[] items; // ������ �����۵�
    //public GameObject item;
    public Transform playerTransform; // �÷��̾��� Ʈ������

    //public float minDistance = 2f; // �÷��̾� ��ġ�κ��� �������� ��ġ�� �ּ� �ݰ�
    //public float maxDistance = 5f; // �÷��̾� ��ġ�κ��� �������� ��ġ�� �ִ� �ݰ�


    public float timeBetSpawnMax = 7f; // �ִ� �ð� ����
    public float timeBetSpawnMin = 2f; // �ּ� �ð� ����
    public float timeBetSpawn; // ���� ����
    // ������ ���� ������ �Ź� �ٸ��� ����

    public float lastSpawnTime; // ������ ���� ����

    private Vector3 randomVectorPos;

    // �� �ȿ����� ������ �� �ֵ��� ���߿� �ϵ��ڵ�
    /*
    public Vector3 baseVertex1;
    public Vector3 baseVertex2;
    public Vector3 baseVertex3;
    public Vector3 baseVertex4;
    */
    public float baseX1;
    public float baseX2;
    public float baseZ1;
    public float baseZ2;


    private void Start()
    {
        // ���� ���ݰ� ������ ���� ���� �ʱ�ȭ
        timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
        lastSpawnTime = 0;
    }


    // �ֱ������� ������ ���� ó�� ����
    /*
    private void Update()
    {
        // ���� ������ ������ ���� �������� ���� �ֱ� �̻� ����
        // && �÷��̾� ĳ���Ͱ� ������
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
    */

    // ���� ������ ���� ó��
    
    protected virtual void Spawn()
    {
        /*
        // �÷��̾� ��ó���� ����޽� ���� ���� ��ġ ��������
        Vector3 spawnPosition =
            GetRandomPoint(playerTransform.position, maxDistance);
        // �ٴڿ��� 0.5��ŭ ���� �ø���
        spawnPosition += Vector3.up * 0.5f;

        // ������ �� �ϳ��� �������� ��� ���� ��ġ�� ����
        //GameObject selectedItem = items[Random.Range(0, items.Length)]; // �� �κ� �ٽ� 
        GameObject selectedItem = SelectRandomItem();
        
        
        GameObject item = Instantiate(selectedItem, spawnPosition, Quaternion.identity);

        // ������ �������� 5�� �ڿ� �ı�
        // Destroy(item, 5f);
        // �ص� �ǰ� �� �ص� �ǰ�
        */
    }

    // ����޽� ���� ������ ��ġ�� ��ȯ�ϴ� �޼���
    // center�� �߽����� distance �ݰ� �ȿ��� ������ ��ġ�� ã�´�
    public Vector2 GetRandomPointOutRange(Vector2 center, float distance) //max distance *1.5f
    {
        // center�� �߽����� �������� maxDistance�� �� �ȿ����� ������ ��ġ �ϳ��� ����
        // Random.insideUnitSphere�� �������� 1�� �� �ȿ����� ������ �� ���� ��ȯ�ϴ� ������Ƽ
        do
        {
            float randomAngle = Random.Range(0f, Mathf.PI * 2f); // 0~360�� ���� �ϳ��� ����
            float randomDistance = Random.Range(distance, distance * 1.5f);

            float x = center.x + Mathf.Cos(randomAngle) * distance;
            float y = center.y + Mathf.Sin(randomAngle) * distance;
            Vector3 randomVectorPos = new Vector3(x, y);
        } while (IsInsideBase(randomVectorPos));
        Vector2 vectorPos = randomVectorPos;
        // ã�� �� ��ȯ
        return vectorPos;
    }

    public Vector2 GetRandomPointInRange(Vector2 center, float distance) // min distance 1f
    {
        // center�� �߽����� �������� maxDistance�� �� �ȿ����� ������ ��ġ �ϳ��� ����
        // Random.insideUnitSphere�� �������� 1�� �� �ȿ����� ������ �� ���� ��ȯ�ϴ� ������Ƽ
        do
        {
            float randomAngle = Random.Range(0f, Mathf.PI * 2f); // 0~360�� ���� �ϳ��� ����
            float randomDistance = Random.Range(1f, distance);

            float x = center.x + Mathf.Cos(randomAngle) * distance;
            float y = center.y + Mathf.Sin(randomAngle) * distance;
            randomVectorPos = new Vector3(x, y);

            // randomVectorPos = Random.insideUnitSphere * distance + center;

        } while (IsInsideBase(randomVectorPos));
        Vector2 vectorPos = randomVectorPos;
        // ã�� �� ��ȯ
        return vectorPos;
    }

    public GameObject SelectRandomItem(GameObject[] itemlist)
    {
        // Time

        GameObject selectedItem = itemlist[Random.Range(0, itemlist.Length)]; // �� �κ� �ٽ�  
        return gameObject;
    }

    public bool IsInsideBase(Vector3 itemVector)
    {
        if ((itemVector.x < baseX2 && itemVector.x < baseX1) && (itemVector.z < baseZ2 && itemVector.z < baseZ1))
            return true;
        else
            return false;
    }
    



}
