using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed = 10.0f;
    Rigidbody2D Rigidbody;
    public Vector3 spawnPoint;
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        //ĳ���Ͱ� ���� ���� ���͸� ���ϰ� RIgidbody�� ���� ���ϴµ� ���⿡ ���װ� ����
        if (Input.GetAxis("Horizontal")>0)
        {
            spawnPoint = Vector3.right;
        }
        if (Input.GetAxis("Horizontal")<0)
        {
            spawnPoint = Vector3.left;
        }
        Rigidbody.velocity = spawnPoint * BulletSpeed;
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�Ѿ��� Player �±׸� ������ �ʴ� ��ü�� ���߸� �����, Enemy �±׸� ���� ��ü�� ���߸� ����ٴ� ������ �߰� �����
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("���� ����");
            Destroy(this.gameObject);
        }
        if(collision.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
