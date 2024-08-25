using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    //�� ���� ���� ����, ���߿� ��ȭ�Ǹ� �ٲ� �� ����
    //public float PistolDamage = 1f; //Bullet.cs�� �̵�
    public float BulletSpeed = 8.0f;
    float FireCoolTime = 0.5f;
    float NextFireTime = 0f;

    public GameObject bulletPos;
    [SerializeField] GameObject BulletPref;
    [SerializeField] AudioClip shootSound;
    private AudioSource audioSource;
    Vector2 BulletDir;
    Camera cam;
    void Start()
    {
        cam = Camera.main;
        audioSource = GetComponent<AudioSource>();
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
            if (Time.time >= NextFireTime)
            {
                GameObject PistolBullet = Instantiate(BulletPref, bulletPos.transform.position, transform.rotation);
                Rigidbody2D rigidbody = PistolBullet.GetComponent<Rigidbody2D>();
                PistolBullet.gameObject.GetComponent<Rigidbody2D>().AddForce(BulletDir * BulletSpeed, ForceMode2D.Impulse);
                audioSource.PlayOneShot(shootSound);
                NextFireTime = Time.time + FireCoolTime;
            }
            else
            {
                Debug.Log("��Ÿ�� �ȵ�");
            }
        }
    }
}
