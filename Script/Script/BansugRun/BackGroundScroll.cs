using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{



    //배경 스크롤
    public float scrollspeed = 0.5f;
    Material myMaterial;

    private void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
    }
    // Update is called once per frame
    void Update()
    {
        float newOffSetX = myMaterial.mainTextureOffset.x + scrollspeed * Time.deltaTime;
        Vector2 newOffset = new Vector2(newOffSetX, 0);

        myMaterial.mainTextureOffset = newOffset;

        //Vector2 textureOffset = new Vector2(Time.time * scrollspeed, 0);
        //quadRenderer.material.mainTextureOffset = textureOffset;


    }
}
