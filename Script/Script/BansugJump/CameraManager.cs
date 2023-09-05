using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject player;
    public ObjectManager om;
    public float x = 0;
    public float y = 0;
    public float z = -10;
    public float temp;



    Vector3 cameraPosition;

    private void Start()
    {
        temp = 0;
    }


    //카메라가 플레이어가 올라간 이후 밑으로 안내려가게 만들기 
    private void LateUpdate()
    {
        if (player.transform.position.y > temp) {

            temp = player.transform.position.y;
        }
        cameraPosition.y = temp;
        cameraPosition.z = player.transform.position.z + z;
        transform.position = cameraPosition;



    }

}
