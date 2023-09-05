using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UiManager : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    public ulong gold=100;

    //재화값 배열 
    private string[] goldUnitArr = new string[] {"", "A", "B", "C", "D", "E", "F", "G", "H",
    "I", "J","K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA" };









//    public Text goldText ;

    //텍스트들 모음 
    public TextMeshProUGUI goldText;

    public TextMeshProUGUI timeValueText;
    public TextMeshProUGUI clickValueText;

    //실질적인 오르는 값들 모음 
    public ulong clickvalue;
    public ulong timevalue;


    //gameManager에서 불러오는 값들도 셋팅 
    private void Start()
    {
        //   timevalue = 2;
        //   clickvalue = 2;


        //clickvalue = PlayerPrefs.GetString("ClickValue");
        StartCoroutine(GetGold(1));
        GetValueText(gold);
        timeValueText.text = "초당 획득:" + (timevalue);
        clickValueText.text = "클릭당 획득:" + clickvalue;
    }


    //시간부분 셋팅 
    public void SetTimeValue(ulong _value) {

        timevalue = _value;
        timeValueText.text = "초당 획득:" + (timevalue);
        GetValueText(gold);
    }
    //클릭부분 셋팅 
    public void SetClickValue(ulong _value) {
        clickvalue = _value;
        clickValueText.text = "클릭당 획득:" + (clickvalue);
        GetValueText(gold);

    }

    //update에서 호출 x
    IEnumerator GetGold(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        //        Debug.Log("1");
        gold += 1 * timevalue;
        GetValueText(gold);
        StartCoroutine(GetGold(1));
    }






    
    //화면 전체에서 값 받아오기 
    public void OnPointerClick(PointerEventData eventData)
    {

        gold += 1*clickvalue;
        GetValueText(gold);
        //        Debug.Log("click");
    }


    //재화 변경 알고리즘 
    public void GetValueText(ulong gold)
    {

        int placeN = 3;
        ulong valueTemp = gold;
        List<ulong> numlist = new List<ulong>();
        ulong p = (ulong)Mathf.Pow(10, placeN);
        do
        {
            numlist.Add((ulong)valueTemp % p);
            valueTemp /= p;
        } while (valueTemp >= 1);

        string retStr = "";
        for (int i = 0; i < numlist.Count; i++)
        {

            retStr = numlist[i] + goldUnitArr[i] + " " + retStr;
        }

        goldText.text = "골드 : "+retStr;


    }

    public void SetGold(ulong _gold) {
        gold = _gold;
        GetValueText(gold);
    }








}
