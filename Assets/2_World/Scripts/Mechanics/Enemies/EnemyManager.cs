using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> enemies;  // ������ ����Ʈ�� �����մϴ�.
    public DoorMover doorMover;        // ���� �����ϴ� DoorMover ��ũ��Ʈ�� ������ �����մϴ�.

    // Update�� �� �����Ӹ��� ȣ��˴ϴ�.
    void Update()
    {
        // �����ִ� ������ �ִ��� Ȯ���մϴ�.
        if (enemies.Count == 0)
        {
            // ���� ��� óġ�Ǿ��� �� ���� ���ϴ�.
            doorMover.OpenDoor();
            // �� �̻� Update�� �������� �ʱ� ���� ��ũ��Ʈ�� ��Ȱ��ȭ�մϴ�.
            this.enabled = false;
        }
    }

    // ���� óġ�� �� ȣ��Ǵ� �޼���
    public void OnEnemyDefeated(GameObject enemy)
    {
        enemies.Remove(enemy);
    }
}

