using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public Transform[] spawnPoint;
    public int delayTime;
    public Transform[] emenySpace;
    public int[] arrint;



    // Start is called before the first frame update
    void Start()
    {
        delayTime = 4;
        StartCoroutine(SpawnEnemy(0));

        arrint = new int[4];
    }



    IEnumerator SpawnEnemy(float _delayTime)
    {
        yield return new WaitForSeconds(_delayTime);

        for (int i = 0; i < spawnPoint.Length; i++) {
            int temp = Random.Range(0,4);
            
            emenySpace[temp].GetChild(arrint[temp]).gameObject.SetActive(true);
            emenySpace[temp].GetChild(arrint[temp]).gameObject.transform.position = spawnPoint[i].transform.position;
            arrint[temp]++;
            if (arrint[temp] >=3) {
                arrint[temp] =0;
            }
        }


        StartCoroutine(SpawnEnemy(delayTime));
    }






    // Update is called once per frame
    void Update()
    {


    }
}
