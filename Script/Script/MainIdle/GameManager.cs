using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;
using UnityEngine.EventSystems;
using System.IO;

public class GameManager : MonoBehaviour
{
    //매니져 가져오기 
    public UiManager um;
    public TokenManager tm;
    public ButtonManager bm;
   // public Bansugi ban;


    //값들 저장 
    [SerializeField]
    ulong timeValue;
    [SerializeField]
    ulong clickValue;
    ulong gold;


    //토큰값들 저장해줄 공간 
    public Transform[] tokenArr;
    public int[] tokenIntArr;
    public Transform parent;
    public ulong tokenvalue;


    //싱글톤 
    public static GameManager instance;


    //private void Awake()
    //{
    //    if (instance != null)
    //    {

    //        Destroy(gameObject);
    //    }
    //    instance = this;

    //    DontDestroyOnLoad(gameObject);

    //}








    //json, playerPrefs에서 저장값 불러오기 
    private void Start()
    {
        string goldtemp = PlayerPrefs.GetString("Gold");
        gold = ulong.Parse(goldtemp);

        gold += (ulong)PlayerPrefs.GetInt("RunScore")*10;
        gold += (ulong)PlayerPrefs.GetInt("JumpScore")*5;



        um.SetGold(gold);

        //  totalValue=PlayerPrefs.GetInt("TimeValue");

        //        string[] tokentemp = PlayerPrefs.GetString("TokenArr").Split(',');



        string fileName = "DataSet";
        string path = Application.persistentDataPath + "/" + fileName + ".Json";
        string json = File.ReadAllText(path);


        JsonDataSet jsonset = JsonUtility.FromJson<JsonDataSet>(json);




        string[] tokentemp = jsonset.tokenvalue.Split(',');

        tokenIntArr = new int[tokentemp.Length];
        for (int i = 0; i < tokentemp.Length; i++)
        {
            tokenIntArr[i] = System.Convert.ToInt32(tokentemp[i]); 
        }


        //string clicktemp = PlayerPrefs.GetString("ClickValue");

        string clicktemp = jsonset.clickvalue;


        tokenArr = new Transform[parent.childCount];
        for (int i = 0; i < tokenArr.Length; i++)
        {
            tokenArr[i] = parent.GetChild(i);
            for (int j = 0; j < tokenIntArr[i]; j++)
            {

                tokenArr[i].GetChild(j).gameObject.SetActive(true);
                Token temp = tokenArr[i].GetChild(j).GetComponent<Token>();
                tokenvalue += temp.tokenValue;
            }

        }

        clickValue = ulong.Parse(clicktemp);
        timeValue = tokenvalue;

        //ui쪽에 전달 
        um.SetTimeValue(timeValue);
        um.SetClickValue(clickValue);

       // SetTimeValue(tokenvalue);
        
    }

    public void SetTimeValue(ulong _timeValue) {
        timeValue += _timeValue;
        um.SetTimeValue(timeValue);
    }
    public void SetGold(ulong _gold) {
        um.gold -= _gold;
    }



    //
   //private void OnApplicationQuit()
   // //private void OnDisable()
   // //private void OnDestroy();
   // {
   //     string goldtemp = um.gold.ToString();

   //     //        Debug.Log("종료시");

   //     //tokenArr = new Transform[parent.childCount];
   //     //tokenIntArr = new int[parent.childCount];



   //     //for (int i = 0; i < tokenArr.Length; i++)
   //     //{
   //     //    Debug.Log("for문시점");
   //     //    tokenArr[i] = parent.GetChild(i);
   //     //    for (int j = 0; j < tokenArr[i].childCount; j++)
   //     //    {

   //     //        if (tokenArr[i].GetChild(j).gameObject.activeSelf)
   //     //        {

   //     //            tokenIntArr[i]++;
   //     //        }
   //     //    }

   //     //}

     
   //     string clicktemp = um.clickvalue.ToString();
   //     string timetemp = um.timevalue.ToString();

   //     string tokentemp = "";
   //     int[] bmarr = bm.tokenArr;
   //     Debug.Log(bmarr.ToString());

   //     for (int i = 0; i < bmarr.Length; i++) // 배열과 ','를 번갈아가며 tempStr에 저장
   //     {
   //         tokentemp = tokentemp + bmarr[i];
   //         if (i < bmarr.Length - 1) // 최대 길이의 -1까지만 ,를 저장
   //         {
   //             tokentemp = tokentemp + ",";
   //         }
   //     }
   //     Debug.Log(tokentemp);
   //     PlayerPrefs.SetString("ClickValue", clicktemp);
   //     PlayerPrefs.SetString("TokenArr", tokentemp);
   //     PlayerPrefs.SetString("Gold", goldtemp);
   // }


    //오브젝트 종료시 저장 
    private void OnDisable()
    {

        JsonDataSet jsonset = new JsonDataSet();


        string goldtemp = um.gold.ToString();
        string clicktemp = um.clickvalue.ToString();
        string timetemp = um.timevalue.ToString();

        string tokentemp = "";
        int[] bmarr = bm.tokenArr;
        Debug.Log(bmarr.ToString());

        for (int i = 0; i < bmarr.Length; i++) 
        {
            tokentemp = tokentemp + bmarr[i];
            if (i < bmarr.Length - 1) 
            {
                tokentemp = tokentemp + ",";
            }
        }
        Debug.Log(tokentemp);

        jsonset.clickvalue = clicktemp;
        jsonset.tokenvalue = tokentemp;

        string json = JsonUtility.ToJson(jsonset);
        string fileName = "DataSet";
        string path = Application.persistentDataPath + "/" + fileName + ".Json";

        File.WriteAllText(path, json);

        //PlayerPrefs.SetString("ClickValue", clicktemp);
        //PlayerPrefs.SetString("TokenArr", tokentemp);
        PlayerPrefs.SetString("Gold", goldtemp);
        PlayerPrefs.SetInt("JumpScore",0);
        PlayerPrefs.SetInt("RunScore", 0);
    }

    //어플리케이션 종료시 저장 
    private void OnApplicationQuit() {
        JsonDataSet jsonset = new JsonDataSet();


        string goldtemp = um.gold.ToString();
        string clicktemp = um.clickvalue.ToString();
        string timetemp = um.timevalue.ToString();

        string tokentemp = "";
        int[] bmarr = bm.tokenArr;
        Debug.Log(bmarr.ToString());

        for (int i = 0; i < bmarr.Length; i++) 
        {
            tokentemp = tokentemp + bmarr[i];
            if (i < bmarr.Length - 1) 
            {
                tokentemp = tokentemp + ",";
            }
        }
        Debug.Log(tokentemp);

        jsonset.clickvalue = clicktemp;
        jsonset.tokenvalue = tokentemp;

        string json = JsonUtility.ToJson(jsonset);
        string fileName = "DataSet";
        string path = Application.persistentDataPath + "/" + fileName + ".Json";

        File.WriteAllText(path, json);

        //PlayerPrefs.SetString("ClickValue", clicktemp);
        //PlayerPrefs.SetString("TokenArr", tokentemp);
        PlayerPrefs.SetString("Gold", goldtemp);
        PlayerPrefs.SetInt("JumpScore", 0);
        PlayerPrefs.SetInt("RunScore", 0);

    }


    //어플 중단시 호{
    private void OnApplicationPause(bool pause)
    {
        JsonDataSet jsonset = new JsonDataSet();


        string goldtemp = um.gold.ToString();
        string clicktemp = um.clickvalue.ToString();
        string timetemp = um.timevalue.ToString();

        string tokentemp = "";
        int[] bmarr = bm.tokenArr;
        Debug.Log(bmarr.ToString());

        for (int i = 0; i < bmarr.Length; i++) 
        {
            tokentemp = tokentemp + bmarr[i];
            if (i < bmarr.Length - 1) 
            {
                tokentemp = tokentemp + ",";
            }
        }
        Debug.Log(tokentemp);

        jsonset.clickvalue = clicktemp;
        jsonset.tokenvalue = tokentemp;

        string json = JsonUtility.ToJson(jsonset);
        string fileName = "DataSet";
        string path = Application.persistentDataPath + "/" + fileName + ".Json";

        File.WriteAllText(path, json);

        //PlayerPrefs.SetString("ClickValue", clicktemp);
        //PlayerPrefs.SetString("TokenArr", tokentemp);
        PlayerPrefs.SetString("Gold", goldtemp);
        PlayerPrefs.SetInt("JumpScore", 0);
        PlayerPrefs.SetInt("RunScore", 0);
    }


}

