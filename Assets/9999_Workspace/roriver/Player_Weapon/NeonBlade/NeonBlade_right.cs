using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeonBlade_right : MonoBehaviour
{
    //네온 블레이드(우) 단검 관련 변수, 나중에 강화되면 바뀔 수 있음
    public float RightBladeDamage = 2f;
    float RIghtBladeCoolTime = 0.5f;
    float NextRightBladeTime = 0f;

    public Transform BladeAttackPos;
    public Vector2 boxSize;
    float attackDirection = 0.7f;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            attackDirection = -0.7f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            attackDirection = 0.7f;
        }
        BladeAttackPos.localPosition = new Vector2(attackDirection, 0);

        Blade_Sweep();
    }
    void Blade_Sweep()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time >= NextRightBladeTime)
            {
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(BladeAttackPos.position, boxSize, 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    //적을 맞출 때 발생하는 이벤트, 이후 적이 구현되면 나중에 수정할 부분임
                    if (collider.tag == "Enemy")
                    {
                        Debug.Log("적을 때림");
                    }
                }

                NextRightBladeTime = Time.time + RIghtBladeCoolTime;
            }
            else
            {
                Debug.Log("네온 블레이드(우) 쿨타임 안됨");
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(BladeAttackPos.position, boxSize);
    }
}
