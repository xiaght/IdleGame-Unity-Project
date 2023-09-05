using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{

    // 오브젝트 풀
    public GameObject Prefab = null;
    public Queue<GameObject> objectQueue = new Queue<GameObject>();
    public Queue<GameObject> objectOutQueue = new Queue<GameObject>();
    public Transform parent;



    public Player_Jump player;

    public Transform clear;


    public int temp;
    public int objectWall = 0;




    //오브젝트 생성이후 비활성/
    private void Start()
    {
        for (int i = 0; i < 7; i++) {
            GameObject objectPool = Instantiate(Prefab, Vector3.zero, Quaternion.identity,parent);
            objectQueue.Enqueue(objectPool);
            objectPool.SetActive(false);
        }
        temp = 0;
        GetQueue();
    }


    //오브젝트 큐에서 뺴
    public GameObject GetQueue()
    {
        GameObject t_Object = objectQueue.Dequeue();
        t_Object.SetActive(true);

        objectOutQueue.Enqueue(t_Object);
        return t_Object;

    }

    //오브젝트 큐에 삽입 
    public void InsertQueue(GameObject p_object)
    {
        objectQueue.Enqueue(p_object);
        p_object.SetActive(false);
    }



    //카메라의 위치값을 기반으로 해당 값을 기준으로 위아래에 오브젝트를 활성화 시켜줌 
    private void Update()
    {

        //활성화 위치 잡기 
        objectWall = (int)(player.transform.position.y+20) / 40;
        if (temp != objectWall) {
            GameObject tempWall = GetQueue();
            tempWall.transform.position = new Vector2(0, objectWall * 40);

            temp = objectWall;

            if (temp > 2)
            {
                GameObject t_Object= objectOutQueue.Dequeue();
                InsertQueue(t_Object);
                for (int i = 0; i < clear.childCount-10; i++)
                {
                    Destroy(clear.GetChild(i).gameObject);
                }
            }

        }



    }
}



