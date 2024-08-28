using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorChanger : MonoBehaviour
{
    // Ŀ���� �̺�Ʈ ����, Color�� ���ڷ� ����
    [System.Serializable]
    public class ColorChangeEvent : UnityEvent<Color> { }

    // �̺�Ʈ �ν��Ͻ� ����
    public ColorChangeEvent onColorChange;

    // ���� ���� �޼���
    public void ChangeColor(Color newColor)
    {
        // Renderer�� ���� ������Ʈ�� ���� ����
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = newColor;
        }

        // �̺�Ʈ ȣ��
        onColorChange.Invoke(newColor);
    }
}

