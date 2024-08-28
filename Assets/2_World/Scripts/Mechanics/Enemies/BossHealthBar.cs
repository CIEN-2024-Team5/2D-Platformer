using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Image healthBarImage; // ü�¹��� �̹���
    public Sprite[] healthBarSprites; // ü�� ���¿� ���� ����� ��������Ʈ �迭 (100%, 80%, 60%, 40%, 20%, 0%)

    private EnemyHealth bossHealth;
    private GameObject player; // �÷��̾� ������Ʈ ����
    public GameObject bossHealthBarUI; // ���� ü�¹� UI (Zone �ȿ����� Ȱ��ȭ)

    void Start()
    {
        bossHealthBarUI.SetActive(false); // ó������ ��Ȱ��ȭ
        player = GameObject.FindWithTag("Player"); // �÷��̾� ������Ʈ ã��
        bossHealth = GetComponentInParent<EnemyHealth>(); // �θ� ������Ʈ�� EnemyHealth ����
    }

    void Update()
    {
        if (bossHealth.currentHealth > 0 && IsPlayerInZone())
        {
            bossHealthBarUI.SetActive(true);
            UpdateHealthBar(bossHealth.currentHealth);
        }
        else
        {
            bossHealthBarUI.SetActive(false);
        }
    }

    private bool IsPlayerInZone()
    {
        // �÷��̾ Zone �ȿ� �ִ��� Ȯ���ϴ� ����
        // �÷��̾�� ������ �Ÿ� �Ǵ� Ư�� Ʈ���Ÿ� ����Ͽ� �÷��̾ Zone�� �ִ��� Ȯ��
        return true; // �ӽ÷� true�� ��ȯ (Zone üũ ���� �߰� �ʿ�)
    }

    public void UpdateHealthBar(int currentHealth)
    {
        int spriteIndex = Mathf.FloorToInt((currentHealth / (float)bossHealth.maxHealth) * (healthBarSprites.Length - 1));
        healthBarImage.sprite = healthBarSprites[spriteIndex];
    }
}


