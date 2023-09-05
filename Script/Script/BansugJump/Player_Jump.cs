using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump : MonoBehaviour
{
    Rigidbody2D rigid;
    CapsuleCollider2D coll;
    //  Animator anim;
    SpriteRenderer sr;

    public Sprite[] anim;



    //상태값 표시 
    bool isWall;
    public bool isJump;
    public bool inputSpace;
    bool jumpbutton;

    //움직임 제어 
    public int dir;
    public int lookdir;
    public int jumpCount;
    public float jumpPower;
    public int speed;
    bool isDeath;


    public HudManager Ui;


    //초기값 셋팅
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        // anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        dir = 1;
        lookdir = 1;
        jumpCount = 3;
        jumpPower = 3f;
        speed = 2;
        isJump = jumpCount == 0 ? false : true;
    }

    //업데이트에서 호출 점프 횟수 기중으로 만들기 
    public void Jump() {

        //방향 
        sr.flipX = lookdir == 1 ? false : true;
        if (!isWall)
        {
            sr.flipX = lookdir == -1 ? false : true;
        }

        //조건  
        isJump = jumpCount == 0 ? false : true;

        //점프 3번까지 
        if ((inputSpace||jumpbutton )&& isJump)
        {
            isWall = true;
            //모바일 기준 점프 셋팅  
            jumpbutton = false;
            if (jumpCount == 3)
            {
             //   rigid.AddForce(new Vector2(dir, jumpPower) * 3, ForceMode2D.Impulse);
              
                rigid.velocity = new Vector2(dir*speed, jumpPower)*3;
                jumpCount--;
                isJump = true;
            
            // anim.SetTrigger("Jump1");

            //    jumpCount--;

            }
            else if (jumpCount == 2)
            {
//                rigid.AddForce(new Vector2(dir, jumpPower) * 3, ForceMode2D.Impulse);
                rigid.velocity = new Vector2(dir*speed, jumpPower) * 3;
                
                //  anim.SetTrigger("Jump2");

                jumpCount--;

            }
            else if (jumpCount == 1)
            {
//                rigid.AddForce(new Vector2(dir, jumpPower) * 3, ForceMode2D.Impulse);
                rigid.velocity = new Vector2(dir*speed, jumpPower) * 3;

                //  anim.SetTrigger("Jump3");

                jumpCount--;

            }

        }
    }
    private void FixedUpdate()
    {
        GetInput();
        Jump();
        

    }

    //키보드 기준 
    public void GetInput()
    {

        inputSpace = Input.GetKeyDown(KeyCode.Space);
    }

    void Update()
    {

    }

    //모바일 기준 
    public void JumpButton() {

        jumpbutton = true;
    }


    //테스트 코드 
    IEnumerator JumpButtonco() {
        yield return new WaitForSecondsRealtime(0.01f);
        inputSpace = false;
    }

    //테스트 코드  
    IEnumerator Down()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        //sr.sprite = anim[7];
        yield return new WaitForSecondsRealtime(0.1f);
    }

    //사망시 저장밑 레이어 수정 
    IEnumerator Death()
    {
        gameObject.layer = 8;
        jumpCount = -4;
        isDeath = true;
        Ui.SetRestartUI();
        PlayerPrefs.SetInt("JumpScore",Ui.scoreInt);
        if (Ui.bestscore < Ui.scoreInt)
        {
            PlayerPrefs.SetInt("MaxScore", Ui.scoreInt);
        }



        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        //sr.sprite = anim[8];
        yield return new WaitForSecondsRealtime(0.5f);
        //sr.sprite = anim[9];
        yield return new WaitForSecondsRealtime(0.1f);
    }



    //사망시 처리 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {


            StartCoroutine(Death());

        }

    }


    //벽 접촉시 처리 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Wall"&&isWall&&!isDeath)
        {
            isWall = false;
            
            Debug.Log("2");
            lookdir *= -1;
            dir *= -1;
            //sr.sprite = anim[6];
            jumpCount = 3;
            StartCoroutine(Down());
        }


    }
    
}
