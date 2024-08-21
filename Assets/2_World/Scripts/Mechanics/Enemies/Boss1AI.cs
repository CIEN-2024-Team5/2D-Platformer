using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Boss1AI : MonoBehaviour
{
    public List<Transform> points;
    public int nextID;
    int idChangeValue = 1;
    public float speed = 2;

    public Transform player;
    public float chaseDistance = 3f;
    public float returnDistance = 5f;
    public float jumpForce = 7f;
    public float diveSpeed = 10f;
    public float diveDelay = 0.5f; // ������� �� ��� �ð�
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Vector2 initialPosition;
    private bool isGrounded;
    private bool isChasingPlayer = false;
    private bool isReturning = false;
    private bool isDiving = false;

    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        initialPosition = transform.position;

        // ����� �α� �߰�
        Debug.Log("EnemyAI Initialized");
    }

    private void Reset()
    {
        Init();
    }

    void Init()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void Update()
    {
        // �÷��̾���� �Ÿ� ���
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // ����� �α� �߰�
        Debug.Log($"Distance to Player: {distanceToPlayer}, Chase Distance: {chaseDistance}");
        Debug.Log($"Is Grounded: {isGrounded}, Is Chasing: {isChasingPlayer}, Is Returning: {isReturning}, Is Diving: {isDiving}");

        if (distanceToPlayer < chaseDistance && isGrounded && !isDiving)
        {
            isChasingPlayer = true;
            isReturning = false;
            ChasePlayer();
        }
        else if (isChasingPlayer && distanceToPlayer > returnDistance)
        {
            isChasingPlayer = false;
            isReturning = true;
        }

        if (isReturning)
        {
            ReturnToInitialPosition();
        }
        else if (!isChasingPlayer && !isReturning && points.Count > 0)
        {
            MoveToNextPoint();
        }
    }

    private void FixedUpdate()
    {
        // ���� üũ
        isGrounded = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);

        // ����� �α� �߰�
        Debug.Log($"Is Grounded Check: {isGrounded}");
    }

    private void ChasePlayer()
    {
        if (!isDiving && isGrounded)
        {
            // ���� ���� (����)�Ͽ� �÷��̾ �����ϵ��� ����
            JumpAndDive();
        }
    }

    private void JumpAndDive()
    {
        // ����
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        StartCoroutine(DiveAttack());
    }

    private IEnumerator DiveAttack()
    {
        // ������� �� ��� �ð� (diveDelay)
        yield return new WaitForSeconds(diveDelay);

        isDiving = true;
        rb.velocity = new Vector2(rb.velocity.x, -diveSpeed);

        // ������ ������ ��ٸ�
        while (!isGrounded)
        {
            yield return null;
        }

        isDiving = false;
    }

    private void ReturnToInitialPosition()
    {
        if (Vector2.Distance(transform.position, initialPosition) > 0.1f)
        {
            if (initialPosition.x > transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            isReturning = false;  // ���� �Ϸ�
        }
    }

    private void MoveToNextPoint()
    {
        Transform goalPoint = points[nextID];
        if (goalPoint.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }

        if (Vector2.Distance(transform.position, goalPoint.position) < 1f)
        {
            if (nextID == points.Count - 1)
                idChangeValue = -1;
            if (nextID == 0)
                idChangeValue = 1;
            nextID += idChangeValue;
        }
    }
}
