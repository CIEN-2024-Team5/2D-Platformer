using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class MovableBlock : MonoBehaviour
{
    public float moveSpeed = 5.0f;  // ����� �̵� �ӵ�
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1;  // �߷��� ������ �޵��� ����
        rb.freezeRotation = true;  // ����� ȸ������ �ʵ��� ����
    }

    void Update()
    {
        if (isMoving)
        {
            // x�����θ� �̵��ϰ� �ϰ�, y���� �߷¿� ���� �ڿ������� �����̰� ����
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // �÷��̾ �浹�� ������ �����ϰ� ���� x�� �������θ� ����
            Vector2 contactPoint = collision.GetContact(0).point;
            Vector2 center = collision.collider.bounds.center;

            Vector2 direction = (contactPoint - center).normalized;

            // x�� �������θ� �����̵��� �����ϰ� y���� �״�� ����
            moveDirection = new Vector2(Mathf.Round(direction.x), 0);

            // ���� �� �̵� ����
            isMoving = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // �÷��̾���� ������ ������ �̵� ����
            isMoving = false;
        }
    }
}
