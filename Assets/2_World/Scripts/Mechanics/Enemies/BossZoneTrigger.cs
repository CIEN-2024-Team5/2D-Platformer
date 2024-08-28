using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossZoneTrigger : MonoBehaviour
{
    public BossHealthBar bossHealthBar; // ���� ü�¹� ��ũ��Ʈ ����
    private bool playerInZone = false;  // �÷��̾ �� �ȿ� �ִ��� ����

    void Start()
    {
        if (bossHealthBar != null)
        {
            bossHealthBar.bossHealthBarUI.SetActive(false); // ó������ ��Ȱ��ȭ
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
            if (bossHealthBar != null)
            {
                bossHealthBar.bossHealthBarUI.SetActive(true); // �÷��̾ ���� ������ ü�¹� Ȱ��ȭ
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
            if (bossHealthBar != null)
            {
                bossHealthBar.bossHealthBarUI.SetActive(false); // �÷��̾ ���� ������ ü�¹� ��Ȱ��ȭ
            }
        }
    }

    void Update()
    {
        if (playerInZone && bossHealthBar != null)
        {
            if (bossHealthBar.bossHealthBarUI.activeSelf == false)
            {
                bossHealthBar.bossHealthBarUI.SetActive(true); // �� �ȿ� ���� �� ����ؼ� ü�¹� Ȱ��ȭ
            }
        }
    }
}


