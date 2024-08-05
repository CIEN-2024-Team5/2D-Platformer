using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlShleid : MonoBehaviour
{
    //���� �� ���� ���� �̼� ������, �޴� ���� ������
    float Speed_reduction = 0.5f;
    //float Damage_reduction = 0.5f;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            PlayerController playerController = GetComponent<PlayerController>();
            if(playerController != null)
            {
                playerController.maxSpeed *= Speed_reduction;
                Debug.Log("���� On");
            }
        }
        if(Input.GetMouseButtonUp(1))
        {
            PlayerController playerController = GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.maxSpeed /= Speed_reduction;
                Debug.Log("���� Off");
            }
        }
    }
}
