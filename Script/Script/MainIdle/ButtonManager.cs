using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.IO;

public class ButtonManager : MonoBehaviour
{
    //매니져 가져오기 
    public TokenManager tm;
    public UiManager um;
    //토큰값 로딩 
    public int[] tokenArr;


    //테스트 코드 
    public void OnClickShopButton(GameObject setActive)
    {
        if (setActive.activeSelf)
        {
            setActive.gameObject.SetActive(false);

        }
        else
        {
            setActive.gameObject.SetActive(true);
        }




    }



    //토큰에 접근해서 해당 값 가져오기 
    public void OnClickBuyToken(Transform TokenParent) {
        int count=0;


        for (int i = 0; i < TokenParent.childCount; i++)
        {
            count+=TokenParent.GetChild(i).gameObject.activeSelf ? +1 : 0;

        }
        if (count >= TokenParent.childCount)
        {
            return;
        }
        Token temp= TokenParent.GetChild(count).gameObject.GetComponent<Token>();
        if (um.gold < temp.gold) {
            return;
        }
        temp.gameObject.SetActive(true);
        temp.StartToken();
        Debug.Log("1:" + temp.tokenValue);
        tm.SendTimeValue(temp.tokenValue);
        tm.SendGoldUse(temp.gold);
        tokenArr[temp.number]++;



    }

    //테스트 코드 
    public void OnTestButton() {
        um.gold += 1000000000;

    }
    //테스트 코드 
    public void OnResetButton() {
        um.gold = 0;
    }
    //테스트 코드 
    public void OnResetAllButton()
    {
        PlayerPrefs.DeleteAll();
        um.SetClickValue(2);
        um.SetTimeValue(2);
        um.SetGold(0);
    }

    //클릭값 상승 
    public void OnClickValueUp()
    {
        if (um.gold < um.clickvalue * 100) {
            return;
        }
        um.gold -= um.clickvalue * 100;
        um.clickvalue++;
        um.SetClickValue(um.clickvalue);


    }

    //테스트 코드 
    public void OnGameStartButton(string sceneName) {
        Loading.LoadScene(sceneName);
    }

    //시작시 json파일 읽어와서 값가져오고 할당해주기 
    private void Start()
    {

        string fileName = "DataSet";
        string path = Application.persistentDataPath + "/" + fileName + ".Json";
        string json = File.ReadAllText(path);


        JsonDataSet jsonset = JsonUtility.FromJson<JsonDataSet>(json);


        string[] tokentemp = jsonset.tokenvalue.Split(',');

        //string[] tokentemp = PlayerPrefs.GetString("TokenArr").Split(',');


        tokenArr = new int[tokentemp.Length]; // 문자열 배열의 크기만큼 정수형 배열 생성

        for (int i = 0; i < tokentemp.Length; i++)
        {
            tokenArr[i] = System.Convert.ToInt32(tokentemp[i]); // 문자열 형태로 저장된 값을 정수형으로 변환후 저장
        }

    }
}
