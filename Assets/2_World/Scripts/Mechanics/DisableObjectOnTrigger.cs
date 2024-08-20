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
        // Ư�� ������Ʈ�� ��Ȱ��ȭ
        if (objectToDisable != null)
        {
            objectToDisable.SetActive(false);
        }
    }
}

