using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioSource bgmSource;         // ���� BGM�� ����ϴ� AudioSource
    public AudioClip gameOverBGM;         // ���� ���� �� ����� BGM
    public AudioClip gameClearBGM;         // ���� ���� �� ����� BGM

    void Start()
    {
        // AudioSource�� �����Ǿ� �ִ��� Ȯ��
        if (bgmSource == null)
        {
            bgmSource = GetComponent<AudioSource>();
        }
    }

    // BGM�� �����ϰ� ���ο� BGM�� ����ϴ� �޼���
    public void PlayGameOverBGM()
    {
        if (bgmSource != null && gameOverBGM != null)
        {
            bgmSource.Stop();                 // ���� BGM ����
            bgmSource.loop = false;           // �ݺ� ��� ����
            bgmSource.clip = gameOverBGM;     // ���� ���� BGM ����
            bgmSource.Play();                 // ���ο� BGM ���
        }
    }

    public void PlayGameClearBGM()
    {
        if (bgmSource != null && gameClearBGM != null)
        {
            bgmSource.Stop();                 // ���� BGM ����
            bgmSource.loop = false;           // �ݺ� ��� ����
            bgmSource.clip = gameClearBGM;     // ���� ���� BGM ����
            bgmSource.Play();                 // ���ο� BGM ���
        }
    }
}
