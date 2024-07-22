using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D Rigidbody;
    void Start()
    {
        
    }
    private void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�Ѿ��� Player �±׸� ������ �ʴ� ��ü�� ���߸� �����, Enemy �±׸� ���� ��ü�� ���߸� ����ٴ� ������ �߰� �����
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("���� ����");
            Destroy(this.gameObject);
        }

        //���̳� �ٴڿ� ����� ��(platform �±׸� ���� ��ü) �Ѿ��� �����
        if (collision.gameObject.tag == "Platform")
        {
            Destroy(this.gameObject);
        }
    }
}
