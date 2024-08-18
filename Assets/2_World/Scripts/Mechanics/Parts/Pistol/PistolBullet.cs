using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float LifeTime = 0.5f;
    public int damage = 5;
    void Start()
    {
        Destroy(gameObject, LifeTime);
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
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            Destroy(this.gameObject);
        }

        //���̳� �ٴڿ� ����� ��(Platform �Ǵ� OneWayPlatform �±׸� ���� ��ü) �Ѿ��� �����
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "OneWayPlatform" )
        {
            // �÷����� BreakablePlatform ��ũ��Ʈ�� ������ �ִ��� Ȯ��
            BreakablePlatform breakablePlatform = collision.gameObject.GetComponent<BreakablePlatform>();
            if (breakablePlatform != null)
            {
                breakablePlatform.TakeDamage(damage);
            }

            Destroy(this.gameObject);
        }
    }
}
