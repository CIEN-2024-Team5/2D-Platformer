using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPressureOnce : MonoBehaviour
{
    public float moveDistance = 3.0f;  // ���� �̵��� �Ÿ�
    public float moveSpeed = 3.0f;     // ���� �̵� �ӵ�

    private Vector3 initialPosition;   // ���� �ʱ� ��ġ
    private Vector3 openPosition;      // ���� ������ ���� ��ġ
    private bool isOpening = false;    // ���� ������ �ִ��� ����

    void Start()
    {
        // �ʱ� ��ġ�� ������ ���� ��ġ ����
        initialPosition = transform.position;
        openPosition = initialPosition + new Vector3(0, moveDistance, 0);
    }

    void Update()
    {
        // ���� ������ ���� ��
        if (isOpening)
        {
            transform.position = Vector3.MoveTowards(transform.position, openPosition, moveSpeed * Time.deltaTime);
            if (transform.position == openPosition)
            {
                isOpening = false;  // ��ǥ ��ġ�� �����ϸ� ������ ����
            }
        }
    }

    // ���� ���� �޼��� (�� ���� ������, ������ ����)
    public void OpenDoor()
    {
        isOpening = true;
    }
}
