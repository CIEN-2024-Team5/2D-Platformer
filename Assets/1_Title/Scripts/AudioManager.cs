using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance = null;
    public AudioSource bgmAudioSource;

    void Awake()
    {
        // Singleton ���� ����: �̹� �ν��Ͻ��� �����ϸ� �ı��ϰ�, �׷��� ������ ����
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // ���� ����� ������ OnSceneLoaded�� ȣ��
        SceneManager.sceneLoaded += OnSceneLoaded;

        // ���� �� ���� �´� BGM ���
        PlayBGMIfNeeded(SceneManager.GetActiveScene().name);
    }

    // ���� �ε�� ������ ȣ��Ǵ� �Լ�
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayBGMIfNeeded(scene.name);
    }

    // Ư�� �������� BGM�� ����ϴ� �Լ�
    private void PlayBGMIfNeeded(string sceneName)
    {
        if (sceneName == "Title" || sceneName == "Main" || sceneName == "Level1" || sceneName == "Level2" || sceneName == "Level3")
        {
            if (!bgmAudioSource.isPlaying)
            {
                bgmAudioSource.Play();
            }
        }
        else
        {
            if (bgmAudioSource.isPlaying)
            {
                bgmAudioSource.Stop();
            }
        }
    }
}
