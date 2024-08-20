using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedDeactivation : MonoBehaviour
{
    public GameObject linkedObject; // ������ ������Ʈ

    void Update()
    {
        if (linkedObject == null || !linkedObject.activeInHierarchy)
        {
            gameObject.SetActive(false); // �� ������Ʈ�� ��Ȱ��ȭ
        }
    }
}

