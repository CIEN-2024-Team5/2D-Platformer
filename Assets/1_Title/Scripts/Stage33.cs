using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage33 : MonoBehaviour
{
    public Button stageButton; // ��ư UI
    public Sprite lockedSprite; // ��� �ִ� ������ ��������Ʈ
    public Sprite unlockedSprite; // ��� ���� ������ ��������Ʈ
    private Image buttonImage; // ��ư�� �̹��� ������Ʈ

    private void Start()
    {
        buttonImage = stageButton.GetComponent<Image>();
        int previousStageCleared = PlayerPrefs.GetInt("Stage32Cleared", 0); // ���� ���������� Ŭ����Ǿ����� Ȯ��

        if (previousStageCleared == 1)
        {
            stageButton.interactable = true; // ��ư Ȱ��ȭ
            buttonImage.sprite = unlockedSprite;
        }
        else
        {
            //spriteRenderer.color = new Color(1, 1, 1, 0.4f);
            stageButton.interactable = false; // ��ư ��Ȱ��ȭ
            buttonImage.sprite = lockedSprite;
        }
    }

    public void Stage33Btn()
    {
        SceneManager.LoadScene("Stage3-3");
    }
}
