using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlatformController : MonoBehaviour
{
    // �÷��� Ȱ��ȭ �� ȣ��Ǵ� �̺�Ʈ
    public UnityEvent onActivate;

    // �÷��� ��Ȱ��ȭ �� ȣ��Ǵ� �̺�Ʈ
    public UnityEvent onDeactivate;

    // ���� �÷����� Ȱ��ȭ ����
    private bool isActive = false;

    void Start()
    {
        // �÷����� ó������ ��Ȱ��ȭ�� ���·� ����
        gameObject.SetActive(false);
    }

    // �ܺο��� ȣ�� ������ Ȱ��ȭ �޼���
    public void ActivatePlatform()
    {
        if (!isActive)
        {
            isActive = true;
            gameObject.SetActive(true);
            onActivate.Invoke();  // Ȱ��ȭ �̺�Ʈ ȣ��
        }
    }

    // �ܺο��� ȣ�� ������ ��Ȱ��ȭ �޼���
    public void DeactivatePlatform()
    {
        if (isActive)
        {
            isActive = false;
            onDeactivate.Invoke();  // ��Ȱ��ȭ �̺�Ʈ ȣ��
            gameObject.SetActive(false);
        }
    }
}
