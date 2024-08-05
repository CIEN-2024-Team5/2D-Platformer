using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlShleid : MonoBehaviour
{
    //위에 것 부터 각각 이속 감소율, 받는 피해 감소율
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
                Debug.Log("방패 On");
            }
        }
        if(Input.GetMouseButtonUp(1))
        {
            PlayerController playerController = GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.maxSpeed /= Speed_reduction;
                Debug.Log("방패 Off");
            }
        }
    }
}
