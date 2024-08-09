using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public DoorPressure doorPressure; // �ڵ��� ��ũ��Ʈ ����
    public string targetTagPlayer = "Player"; // �÷��̾ Ư�� ����� �±�
    public string targetTagBlock = "MovableBlock";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTagPlayer) || other.CompareTag(targetTagBlock))
        {
            doorPressure.OpenDoor();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(targetTagPlayer) || other.CompareTag(targetTagBlock))
        {
            doorPressure.CloseDoor();
        }
    }
}
