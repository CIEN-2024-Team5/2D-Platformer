using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public Button yourButton;       // ��ư
    public AudioClip clickSound;    // Ŭ�� ����
    private AudioSource audioSource; // ����� �ҽ�

    void Start()
    {
        if (yourButton == null)
        {
            Debug.LogError("Button is not assigned!");
            return;
        }

        // ����� �ҽ� �߰� �� ����
        audioSource = gameObject.AddComponent<AudioSource>();
        if (clickSound == null)
        {
            Debug.LogError("AudioClip is not assigned!");
            return;
        }
        audioSource.clip = clickSound;

        // ��ư Ŭ�� �̺�Ʈ�� �޼��� �߰�
        yourButton.onClick.AddListener(PlaySound);
    }

    void PlaySound()
    {
        if (audioSource != null)
        {
            Debug.Log("Audio Playing");
            audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioSource is not initialized!");
        }
    }
}


