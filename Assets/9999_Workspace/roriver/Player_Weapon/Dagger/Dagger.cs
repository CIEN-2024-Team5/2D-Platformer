using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MonoBehaviour
{
    //서슬퍼런 단검 관련 변수, 나중에 강화되면 바뀔 수 있음
    public float DaggerDamage =1f;
    float DaggerCoolTime = 1f;
    float NextDaggerTime = 0f;

    public Transform DaggerAttackPos;
    public Vector2 boxSize;
    float attackDirection = 0.7f;

    void Start()
    {
        
    }
    void Update()
    {
        //캐릭터가 보는 방향에 맞게 칼 판정 범위 이동
        if (Input.GetKey(KeyCode.A))
        {
            attackDirection = -0.7f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            attackDirection = 0.7f;
        }
        DaggerAttackPos.localPosition = new Vector2(attackDirection, 0);

        Dagger_Sweep();
    }
    void Dagger_Sweep()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(Time.time >= NextDaggerTime)
            {
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(DaggerAttackPos.position, boxSize, 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    //적을 맞출 때 발생하는 이벤트, 이후 적이 구현되면 나중에 수정할 부분임
                    if(collider.tag == "Enemy")
                    {
                        Debug.Log("적을 때림");
                    }
                }

                NextDaggerTime = Time.time + DaggerCoolTime;
            }
            else
            {
                Debug.Log("대거 쿨타임 안됨");
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(DaggerAttackPos.position, boxSize);
    }
}
