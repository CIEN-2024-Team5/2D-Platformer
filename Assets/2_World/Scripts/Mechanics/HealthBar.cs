using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage; // ü�¹��� �̹���
    public Sprite[] healthBarSprites; // ü�� ���¿� ���� ����� ��������Ʈ �迭 (100%, 80%, 60%, 40%, 20%, 0%)

    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        UpdateHealthBar(playerHealth.currentHealth);
    }

    public void UpdateHealthBar(float currentHealth)
    {
        int spriteIndex = Mathf.FloorToInt((currentHealth / playerHealth.maxHealth) * (healthBarSprites.Length - 1));
        healthBarImage.sprite = healthBarSprites[spriteIndex];
    }
}

