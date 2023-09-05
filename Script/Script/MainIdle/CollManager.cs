using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollManager : MonoBehaviour
{
    // Start is called before the first frame update

   // public BoxCollider2D shopColl;
    public RectTransform ShopUi;





    //플레이어랑 접촉시 오브젝트 활성화 나가면 해제 
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ShopUi.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ShopUi.gameObject.SetActive(false);
        }

    }

}
