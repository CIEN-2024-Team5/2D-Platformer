using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObjectOnTrigger : MonoBehaviour
{
    // ��Ȱ��ȭ�� ������Ʈ�� ������ public ����
    public GameObject objectToDisable;

    // Collider2D�� Trigger ������ �������� �� ȣ��Ǵ� �޼���
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Ʈ���ſ� ������ ������Ʈ�� �±װ� "Player"�� ��쿡�� ����
        if (other.CompareTag("Player"))
        {
            // Ư�� ������Ʈ�� ��Ȱ��ȭ
            if (objectToDisable != null)
            {
                objectToDisable.SetActive(false);
            }
        }
    }
}

