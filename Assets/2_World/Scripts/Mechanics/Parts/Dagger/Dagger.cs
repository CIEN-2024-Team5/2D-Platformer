using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MonoBehaviour
{
    //�����۷� �ܰ� ���� ����, ���߿� ��ȭ�Ǹ� �ٲ� �� ����
    public float DaggerDamage =1f;
    float DaggerCoolTIme = 1f;
    float NextDaggerTime = 0f;
    void Start()
    {

    }
    void Update()
    {
        Sweep();
    }
    void Sweep()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(Time.time >= NextDaggerTime)
            {
                
                NextDaggerTime = Time.time + DaggerCoolTIme;
            }
            else
            {
                Debug.Log("��Ÿ�� �ȵ�");
            }
        }
    }
}
