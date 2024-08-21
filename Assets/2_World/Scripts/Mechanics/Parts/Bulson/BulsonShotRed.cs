using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulsonShotRed : MonoBehaviour
{
    public PlayerStatus status;

    public int AttackBonus = 5;

    void Awake()
    {
        // PlayerPrefs���� BulsonShotRed ������ ȿ�� Ȱ��ȭ ���� �ҷ�����
        if (PlayerPrefs.GetInt("BulsonShotRedEnabled", 0) == 1)
        {
            this.enabled = true;
        }
        else
        {
            this.enabled = false;
        }
    }

    void OnEnable()
    {
        if (status != null)
        {
            status.ModifyStats(AttackBonus, 0, 0, 0);
        }
    }
    void OnDisable()
    {
        if (status != null)
        {
            status.RevertStats(AttackBonus, 0, 0, 0);
        }
    }
}
