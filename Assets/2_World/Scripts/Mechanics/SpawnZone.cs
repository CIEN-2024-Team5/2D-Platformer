using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    public EnemySpawner enemySpawner; // �� ��ȯ ��ũ��Ʈ�� ������ ����

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // �÷��̾� �±� Ȯ��
        {
            enemySpawner.StartSpawning(); // �� ��ȯ ����
        }
    }

    /*
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemySpawner.StopSpawning(); // �� ��ȯ ����
        }
    }
    */
}

