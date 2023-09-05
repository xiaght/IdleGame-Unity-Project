using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rigid;
    public Transform trans;


    public SpriteRenderer sr;

    public bool up;
    public bool down;

    public bool upUi;
    public bool downUi;

    float jumpPower;
    float downPower;
    int jumpCount;
    bool isJump;

    public ButtonRunManager Ui;
    public GameObject RestartUi;

    public int hp;


    private void Start()
    {
        jumpPower = 20;
        jumpCount = 2;
        hp = 200;
        downPower = 20;
        Ui.SetHpText(hp);
    }

    private void Update()
    {
        GetKey();
        UpMove();
        DownMove();
    }

    public void GetKey() {

        up = Input.GetKeyDown(KeyCode.W);
        down = Input.GetKey(KeyCode.S);


    }

    public void UpMove() {
        if ((up || upUi) && jumpCount > 0) {
            //        Debug.Log("1");
            //        rigid.AddForce(Vector2.up*jumpPower, ForceMode2D.Impulse);
            upUi = false;
            Debug.Log("playerup");
            rigid.velocity = Vector2.up * jumpPower;
            jumpCount--;
        }


    }
    public void DownMove() {

        if (down || downUi)
        {
            gameObject.transform.localScale = new Vector2(1, 0.5f);
            //  coll.size.y=
            // rigid.AddForce(Vector2.down * jumpPower, ForceMode2D.Impulse);
            rigid.velocity = Vector2.down * downPower;
        }
        else {
            gameObject.transform.localScale = new Vector2(1, 1);

        }

    }


    public void UpButton() {
        upUi = true;

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
         //   Debug.Log("2");
            isJump = false;
            jumpCount = 2;

        }
    }

    public void OnDamage(int damage) {

        sr.color = new Color(0.5f, 0.5f, 0.5f, 0.7f);
        hp -= damage;
        Ui.SetHpText(hp);
        StartCoroutine(OnDamageColor()); 
        if (hp <= 0) {

            Time.timeScale = 0;
            RestartUi.SetActive(true);
            PlayerPrefs.SetInt("RunScore", (int)Ui.scoreInt);
            if (Ui.bestscore < Ui.scoreInt)
            {
                PlayerPrefs.SetInt("MaxScoreRun", (int)Ui.scoreInt);
            }

        }
    }

    IEnumerator OnDamageColor()
    {
        yield return new WaitForSecondsRealtime(1);
        sr.color = new Color(1f, 1f, 1f, 1f);
 //       sr.color = new Color(1, 1, 1, 1);

    }



}
