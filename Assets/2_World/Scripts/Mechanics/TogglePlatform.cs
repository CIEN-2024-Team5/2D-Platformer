using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    private Renderer objectRenderer;
    private Collider2D objectCollider;
    private bool isPlayerInside = false;  // �÷��̾ Ʈ���� �ȿ� �ִ��� ���θ� ����

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        objectCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        // �÷��̾ Ʈ���� �ȿ� ���� ���� �� ������Ʈ�� Ȱ��ȭ
        if (!isPlayerInside && !objectRenderer.enabled)
        {
            ReactivateObject();
        }
    }

    // �÷��̾ Ʈ���ſ� ������ �� ȣ��
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // �÷��̾ Ʈ���� �ȿ� ������ ����ϰ� ������Ʈ�� ��Ȱ��ȭ
            isPlayerInside = true;
            objectRenderer.enabled = false;
            objectCollider.enabled = false;
        }
    }

    // �÷��̾ Ʈ���Ÿ� ��� �� ȣ��
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // �÷��̾ Ʈ���� ������ �������� ���
            isPlayerInside = false;
        }
    }

    private void ReactivateObject()
    {
        objectRenderer.enabled = true;
        objectCollider.enabled = true;
    }
}

