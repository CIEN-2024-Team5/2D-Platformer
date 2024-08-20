using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B502 : MonoBehaviour
{
    //�� ���� ���� ����, ���߿� ��ȭ�Ǹ� �ٲ� �� ����
    //public float B502Damage = 5f; //Bullet.cs�� �̵�
    public float BulletSpeed = 8.0f;
    float B502FireCoolTime = 1f;
    float B502NextFireTime = 0f;

    public GameObject bulletPos;
    [SerializeField] GameObject BulletPref;
    Vector2 BulletDir;
    Camera cam;
    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        Shoot();
        BulletDir = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(BulletDir.y, BulletDir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        BulletDir.Normalize();
    }
    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time >= B502NextFireTime)
            {
                GameObject PistolBullet = Instantiate(BulletPref, bulletPos.transform.position, transform.rotation);
                Rigidbody2D rigidbody = PistolBullet.GetComponent<Rigidbody2D>();
                PistolBullet.gameObject.GetComponent<Rigidbody2D>().AddForce(BulletDir * BulletSpeed, ForceMode2D.Impulse);

                B502NextFireTime = Time.time + B502FireCoolTime;
            }
            else
            {
                Debug.Log("��Ÿ�� �ȵ�");
            }
        }
    }
}
