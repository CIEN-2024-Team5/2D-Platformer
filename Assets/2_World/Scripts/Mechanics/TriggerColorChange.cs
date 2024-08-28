using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerColorChange : MonoBehaviour
{
    public ColorChanger colorChanger; // ColorChanger ��ũ��Ʈ�� ����
    public Color targetColor = Color.red; // ������ ���� ����

    void Update()
    {
        // �����̽��ٸ� ������ ���� ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (colorChanger != null)
            {
                colorChanger.ChangeColor(targetColor);
            }
        }
    }
}

