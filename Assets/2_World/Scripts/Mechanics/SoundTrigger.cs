using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public AudioSource audioSource;  // ȿ������ ����� AudioSource
    private bool isPlayerInside = false;  // �÷��̾ ���� �ȿ� �ִ��� Ȯ���ϴ� �÷���
    private bool isZoneEnabled = true;  // ������ Ȱ��ȭ�Ǿ� �ִ��� Ȯ���ϴ� �÷���

    void Update()
    {
        // ������ Ȱ��ȭ�� ��쿡�� ������� ���
        if (isZoneEnabled && isPlayerInside && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else if (!isZoneEnabled && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    // �÷��̾ Ʈ���� ������ ������ �� ȣ��
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isZoneEnabled && other.CompareTag("Player"))
        {
            isPlayerInside = true;
            audioSource.Play();
        }
    }

    // �÷��̾ Ʈ���� �������� ������ �� ȣ��
    private void OnTriggerExit2D(Collider2D other)
    {
        if (isZoneEnabled && other.CompareTag("Player"))
        {
            isPlayerInside = false;
            audioSource.Stop();
        }
    }

    // �ܺο��� ȣ���Ͽ� ������ ��Ȱ��ȭ�ϴ� �Լ�
    public void DisableZone()
    {
        isZoneEnabled = false;
        audioSource.Stop();  // ���� ��� ���� ������� ����
    }

    // �ܺο��� ȣ���Ͽ� ������ Ȱ��ȭ�ϴ� �Լ� (���� ����)
    public void EnableZone()
    {
        isZoneEnabled = true;
    }
}

