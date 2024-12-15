using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRandomSpawn : MonoBehaviour
{
    public GameObject Spawn_Monster; // 스폰할 몬스터
    public int spawnCount = 10;
    
    private Renderer objectRenderer;

    private void Start()
    {
        // 기준 오브젝트의 Renderer 가져오기
        objectRenderer = GetComponent<Renderer>();

        if (objectRenderer == null)
        {
            return;
        }

        SpawnObjects();
    }

    private void SpawnObjects()
    {
        // 기준 오브젝트의 경계(Bounds) 계산
        Bounds bounds = objectRenderer.bounds;

        for (int i = 0; i < spawnCount; i++)
        {
            float fixedY = 0.5f; // 생성되는 오브젝트의 Y축을 특정위치로 고정
            // 경계 내에서 랜덤 위치 생성
            Vector3 randomPosition = new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                fixedY, // 높이를 기준 오브젝트의 중앙으로 고정
                Random.Range(bounds.min.z, bounds.max.z)
            );

            // 오브젝트 생성
            Instantiate(Spawn_Monster, randomPosition, Quaternion.identity);
        }
    }
}
