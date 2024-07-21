using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    //���ݷ� ���� ����, ��ȭ �ɷ� ������ ����� �� �ִ� ��ġ
    public float attack = 1f;
    public float BulletSpeed = 8.0f;
    [SerializeField] GameObject BulletPref;
    int rotation;
    void Start()
    {
        
    }

    void Update()
    {
        //���߿� ���⿡ ���� ������ ���� �� ���� (�ӽ� �ڵ�)
        if(Input.GetAxis("Horizontal")>0)
        {
            rotation = 1;
        }
        else
        {
            rotation = -1;
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject Bullet = Instantiate(BulletPref, transform.position, transform.rotation);
            Rigidbody2D rigidbody = Bullet.GetComponent<Rigidbody2D>();
            rigidbody.velocity = Vector2.right * rotation * BulletSpeed;
        }
    }
}
