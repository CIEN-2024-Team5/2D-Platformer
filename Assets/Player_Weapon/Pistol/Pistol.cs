using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    //���ݷ� ���� ����, ��ȭ �ɷ� ������ ����� �� �ִ� ��ġ
    public float attack = 1f;
    public float BulletSpeed = 8.0f;
    public GameObject BulletPref;
    public Transform BulletPos;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject Bullet = Instantiate(BulletPref, BulletPos.position, transform.rotation);
        }
    }
}
