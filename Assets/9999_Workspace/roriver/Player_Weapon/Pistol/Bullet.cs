using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float LifeTime = 0.5f;
    void Start()
    {
        Destroy(gameObject,LifeTime);
    }
    private void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�Ѿ��� Player �±׸� ������ �ʴ� ��ü�� ���߸� �����, Enemy �±׸� ���� ��ü�� ���߸� ����ٴ� ������ �߰� �����
        if (collision.gameObject.tag == "Enemy")
        {
            //���� ���� �� �߻��ϴ� �̺�Ʈ, ���� ���� �����Ǹ� ���߿� ������ �κ���
            Debug.Log("���� ����");
            Destroy(this.gameObject);
        }

        //���̳� �ٴڿ� ����� ��(Platform �Ǵ� OneWayPlatform �±׸� ���� ��ü) �Ѿ��� �����
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "OneWayPlatform" )
        {
            Destroy(this.gameObject);
        }
    }
}
