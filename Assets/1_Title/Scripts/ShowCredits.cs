using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCredits : MonoBehaviour
{
    // ũ���� ȭ���� ��� �г��� �����ϱ� ���� public ����
    public GameObject creditsPanel;

    // ũ���� ȭ���� �����ִ� �Լ�
    public void ShowCreditsPanel()
    {
        creditsPanel.SetActive(true); // ũ���� ȭ�� Ȱ��ȭ
    }

    // ũ���� ȭ���� ����� �Լ�
    public void HideCreditsPanel()
    {
        creditsPanel.SetActive(false); // ũ���� ȭ�� ��Ȱ��ȭ
    }
}

