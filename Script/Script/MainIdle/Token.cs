using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{

    //이동값 
    public float ranx = 0;
    public float rany = 0;
    public float speed = 1;
    public float rotateSpeed=5;
    public int ranRotate;

    //토큰 저장값 
    public ulong tokenValue;
    public ulong gold;
    public int number;

    //다른곳에서 부를때 호출 
    public  void StartToken()
    {
        Debug.Log("2");
        transform.position = new Vector3(Random.Range(-20, 40), Random.Range(-4, 8), 0);
        StartCoroutine(Think(0));
    }

    //시작시점 
    private void Start()
    {
        transform.position = new Vector3(Random.Range(-20, 40), Random.Range(-4, 8), 0);

        StartCoroutine(Think(0));
    }

    //움직임 랜덤부분 
    IEnumerator Think(float delayTime)
    {

        yield return new WaitForSeconds(delayTime);
        ranx = Random.Range(-1.0f, 1.0f);
        rany = Random.Range(-1.0f, 1.0f);
        ranRotate = Random.Range(0, 3);

        //재귀로 계속 랜덤값 수정
        StartCoroutine(Think(3));
    }

    //
    private void FixedUpdate()
    {
        transform.position += new Vector3(ranx, rany, 0) * speed * Time.deltaTime;
        if (ranRotate == 0)
        {
            transform.Rotate(Time.deltaTime * rotateSpeed, 0, 0);
        }
        else if (ranRotate == 1)
        {
            transform.Rotate(0, Time.deltaTime * rotateSpeed, 0);

        }
        else {
            transform.Rotate(0,0, Time.deltaTime * rotateSpeed);

        }
    }




}
