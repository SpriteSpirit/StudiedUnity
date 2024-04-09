using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelController : MonoBehaviour
{
    [SerializeField] private List<GameObject> levelPrefab = new List<GameObject>();
    [SerializeField] private List<GameObject> levels = new List<GameObject>();

    private Transform player;

    public float spawnPos = 0;
    public float levelLength = 200;
    private int startLevels = 2;

    public GameObject heartPrefab;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        for (var i = 0; i <= startLevels; i++)
        {
            SpawnLevel(Random.Range(0, levelPrefab.Count));
        }
        //SpawnLevel(0);
    }
    void Update()
    {
        if (player.position.z > spawnPos - levelLength * startLevels) // 
        {
            SpawnLevel(Random.Range(0, levelPrefab.Count));
        }

        // �������� �� ������� ������� � ������ (�� 0 �� ����� ������)
        for (int i = 0; i < levels.Count; i++)
        {
            // ��������� ���������� level ������������ �� ������� �������� � ������ 
            // + �������� transform ������� ��� ����������� ��������� 
            Transform level = levels[i].transform;

            // ���� ������� ������ �� ��� z < ������� ������ �� ��� z - ����� ������
            // ���������� 1: 0 < 210 - 200 => 0 < 10 => true
            // ���������� 2: 0 < 200 - 200 => 0 < 0 => false
            // ��� ��������, ��� ����� ������ ���� �� ��������� ����� 200 ������ �� ���� ������, ������� ����� �������
            // 0[_____]200[__plr__]400[_____]600[_____]800[_____]
            if (level.position.z < player.position.z - levelLength)
            {
                Debug.Log($"������������ ������� {level.name} � ������� Z: {level.position.z}.\n" +
                    $"��������� ������ �� ������ �����: {player.position.z - level.position.z} ������");
                // ������� ������� �� ������ �������
                levels.RemoveAt(i);
                // ���������� ������� ������
                Destroy(level.gameObject);
            }
            else
            {
                // ���� �� ���������, ������ ������
                // Debug.Log($"������� ��� �������� ���. ����� ������ ������� �� ���������� �� ������: {player.position.z - level.position.z} ������");
            }
        }
    }

    private void SpawnLevel(int tileIndex)
    {
        GameObject level = Instantiate(levelPrefab[tileIndex], transform.forward * spawnPos, transform.rotation);
        spawnPos += levelLength;
        SpawnHearts(level);

        // ��������� ������� � ������ �������
        levels.Add(level);
    }

    private void SpawnHearts(GameObject place)
    {
        // �������� ������� ������
        Collider levelCollider = place.GetComponent<Collider>();
        if (levelCollider != null)
        {
            Vector3 minPosition = levelCollider.bounds.min;
            Vector3 maxPosition = levelCollider.bounds.max;

            // �������� ��������� ���������� ��������, ������� ����� �������
            int numHearts = 1;//Random.Range(1, 3);

            // ���������� �� ������� �������� � ������� ��� � ��������� ����������� ������ ������
            for (int i = 0; i < numHearts; i++)
            {
                Vector3 heartPosition = new Vector3(
                    Random.Range(minPosition.x, maxPosition.x),
                    Random.Range(minPosition.y, maxPosition.y),
                    Random.Range(minPosition.z, maxPosition.z)
                );

                Instantiate(heartPrefab, place.transform.position + heartPosition, Quaternion.identity);

            }
        }
    }
}
