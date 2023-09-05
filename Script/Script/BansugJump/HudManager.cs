using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HudManager : MonoBehaviour
{
    public Button restartButton;
    public RectTransform title;
    public Text score;
    public int scoreInt;
    public Text bestScoreText;
    public int bestscore;
    public CameraManager cm;



    //재시작시 로딩창으로 
    public void OnClickRestart() {
       
     //   SceneManager.LoadScene(0);
        Loading.LoadScene("MainIdle");
    }
    public void OnClickstart()
    {

        title.gameObject.SetActive(false);
    }

    //테스트 코드 
    public void OnClickExit()
    {

#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    //최고점수 셋팅 
    private void Start()
    {
        bestscore=PlayerPrefs.GetInt("MaxScore");
        bestScoreText.text = "Best Score : " + bestscore;
    }


    public void SetRestartUI() {
        restartButton.gameObject.SetActive(true);
    }
    


    // 점수쪽만 업데이트
    void Update()
    {
        scoreInt = (int)cm.transform.position.y;
        score.text = "Score : " + scoreInt;
    }
}
