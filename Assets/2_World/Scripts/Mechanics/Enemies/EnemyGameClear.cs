using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGameClear : MonoBehaviour
{
    public GameManagerScript gameManager;
    public GameObject player;

    public int stageNumber; // ���� �������� ��ȣ
    public GameObject[] enemies; // �� ������Ʈ �迭

    private void Start()
    {
        // �� �迭 �ʱ�ȭ
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void Update()
    {
        // ���� ��� óġ�Ǿ����� Ȯ��
        if (AreAllEnemiesDefeated())
        {
            GameCleared();
        }
    }

    private bool AreAllEnemiesDefeated()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null) // ���� �����ϴ� ���� �ִٸ�
            {
                return false;
            }
        }
        return true; // ��� ���� óġ�Ǿ��ٸ�
    }

    private void GameCleared()
    {
        Debug.Log("Game Cleared");
        player.SetActive(false);
        if (gameManager != null)
        {
            gameManager.gameClear();
            PlayerPrefs.SetInt("Stage" + stageNumber + "Cleared", 1); // �������� Ŭ���� ���� ����
        }
        else
        {
            Debug.LogError("GameManagerScript is not assigned.");
        }
    }
}
