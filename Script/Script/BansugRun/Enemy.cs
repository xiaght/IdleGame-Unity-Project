using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int damage=20;
    public int speed;

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player")) {

    //        Player temp = collision.gameObject.GetComponent<Player>();
    //       // temp.hp -= damage;
    //        temp.OnDamage(damage);
    //    }
    //}

    private void Start()
    {
        speed = -10;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Player temp = collision.gameObject.GetComponent<Player>();
            // temp.hp -= damage;

            temp.OnDamage(damage);
        }
        if (collision.CompareTag("Wall"))
        {
            transform.gameObject.SetActive(false);
        }


    }

    private void Update()
    {
        transform.position += new Vector3( 1, 0)*speed*Time.deltaTime;
    }
}
