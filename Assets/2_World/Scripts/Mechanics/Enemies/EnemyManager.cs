using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> enemies;    // ������ ����Ʈ�� �����մϴ�.
    public DoorMover doorMover;         // ���� �����ϴ� DoorMover ��ũ��Ʈ�� ������ �����մϴ�.
    public GameObject objectToToggle;   // Ȱ��ȭ/��Ȱ��ȭ�� ������Ʈ�� ������ �����մϴ�

    // ���� óġ�� �� ȣ��Ǵ� �޼���
    public void OnEnemyDefeated(GameObject enemy)
    {
        Debug.Log("Check Kill");
        enemies.Remove(enemy);
        Destroy(enemy);

        // �����ִ� ������ �ִ��� Ȯ���մϴ�.
        if (enemies.Count == 0)
        {
            Debug.Log("All enemies defeated");

            // ���� ��� óġ�Ǿ��� �� ���� ���ϴ�.
            if (doorMover != null)
            {
                doorMover.OpenDoor();
            }

            // Ư�� ������Ʈ�� Ȱ��ȭ/��Ȱ��ȭ ��� �߰�
            if (objectToToggle != null)
            {
                Debug.Log("Activating object");
                objectToToggle.SetActive(true);
            }

            // �� �̻� �� ��ũ��Ʈ�� �ʿ����� �ʽ��ϴ�.
            this.enabled = false;
        }
    }
}
