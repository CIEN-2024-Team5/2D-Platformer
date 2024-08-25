using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSoundEffect : MonoBehaviour
{
    public AudioClip hitSound;  // �ǰ� ȿ���� Ŭ��
    private AudioSource audioSource;

    void Start()
    {
        // AudioSource ������Ʈ ��������
        audioSource = GetComponent<AudioSource>();

        // AudioSource ������Ʈ�� ������ �ڵ����� �߰�
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // AudioSource �⺻ ����
        audioSource.playOnAwake = false;
        audioSource.clip = hitSound;
    }

    // EnemyHealth ��ũ��Ʈ���� �������� ���� �� ȣ��� �޼���
    public void PlayHitSound()
    {
        if (audioSource != null && hitSound != null)
        {
            Debug.Log("Sound Playing");
            audioSource.PlayOneShot(hitSound);
        }
    }
}
