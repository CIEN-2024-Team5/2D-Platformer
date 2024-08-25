using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    public DoorPressure doorPressure; // �ڵ��� ��ũ��Ʈ ����
    public DoorPressureOnce doorPressureOnce;
    public GameObject platform;
    public string targetTagPlayer = "Player"; // �÷��̾ Ư�� ����� �±�
    public string targetTagBlock = "MovableBlock";
    [Header("Custom Event")]
    public UnityEvent customEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTagPlayer) || other.CompareTag(targetTagBlock))
        {
            if (doorPressure != null)
            {
                doorPressure.OpenDoor();
            }
            if (doorPressureOnce != null)
            {
                doorPressureOnce.OpenDoor();
            }
            if (platform != null)
            {
                platform.SetActive(true);
            }
            customEvent.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(targetTagPlayer) || other.CompareTag(targetTagBlock))
        {
            if (doorPressure != null)
            {
                doorPressure.CloseDoor();
            }
            if (platform != null)
            {
                platform.SetActive(false);
            }
        }
    }
}
