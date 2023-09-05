using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bansugi : MonoBehaviour
{
    //조이스틱 값 가져오
    public JoyStick moveStick;

    public UiManager um;

    
    public Rigidbody2D rigid;
    public SpriteRenderer sr;


    public float speed;
    public Vector2 moveVec;

    


    

    void Update()
    {

    Move();
    }





    void Move()
    {
        moveVec = new Vector3(moveStick.m_vecMove.x, moveStick.m_vecMove.y).normalized;//////////////////////
        moveVec = moveStick.m_vecMove.normalized;

        ////////////////////////////////////////////////  관성줄지말지 고민 //////////////////////////////////

        rigid.velocity = moveVec * speed;
        //rigid.AddForce(moveVec * speed);

        if (moveVec.x < 0)
        {
            sr.flipX = true;
        }
        else
        {

            sr.flipX = false;
        }



    }






}
