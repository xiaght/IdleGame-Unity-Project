using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonRunManager : MonoBehaviour
{

    //버튼밑 Ui가져오기
    public Button restartButton;
    public RectTransform title;
    public Text score;
    public float scoreInt=0;
    public Text bestScoreText;
    public int bestscore;

    public Text HpText;



    public void OnClickRestart()
    {
        Time.timeScale = 1;
       // SceneManager.LoadScene(0);

        Loading.LoadScene("MainIdle");
    }
    public void OnClickstart()
    {

        Time.timeScale = 1;
        title.gameObject.SetActive(false);
    }
    public void OnClickExit()
    {

#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }


    private void Start()
    {
        Time.timeScale = 0;
        bestscore = PlayerPrefs.GetInt("MaxScoreRun");
        bestScoreText.text = "Best Score : " + bestscore;
    }


    public void SetRestartUI()
    {
        restartButton.gameObject.SetActive(true);
    }



    // Update is called once per frame
    void Update()
    {
        scoreInt += Time.deltaTime;
        score.text = "Score : " + (int)scoreInt;
    }


    public void SetHpText(int _value) {
        HpText.text = "200/"+_value.ToString();

    }

}
