using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    public int health = 1;  // �÷����� ü��
    //public GameObject brokenPlatformPrefab;  // �μ��� �÷����� ������

    // źȯ�� �浹 �� ȣ��� �޼���
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            BreakPlatform();
        }
    }

    void BreakPlatform()
    {
        // �μ��� �÷��� ����
        /*
        if (brokenPlatformPrefab != null)
        {
            Instantiate(brokenPlatformPrefab, transform.position, transform.rotation);
        }
        */

        // ���� �÷��� ������Ʈ ����
        Destroy(gameObject);
    }
}
