using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // ��ȯ�� �� ������
    public float spawnInterval = 2.0f; // �� ��ȯ ����
    private bool isSpawning = false;

    public void StartSpawning()
    {
        if (enemyPrefab != null)
        {
            if (!isSpawning)
            {
                isSpawning = true;
                StartCoroutine(SpawnEnemies());
            }
        }
        
    }

    public void StopSpawning()
    {
        isSpawning = false;
        StopCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (isSpawning)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

