using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DownUi : MonoBehaviour, IDragHandler,IEndDragHandler,IPointerDownHandler,IPointerUpHandler
{

    public Player player;


    public void OnDrag(PointerEventData eventData)
    {
        player.downUi = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        player.downUi = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
         player.downUi = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        player.downUi = false;
    }
}
