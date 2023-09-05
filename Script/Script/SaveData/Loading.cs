using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Loading : MonoBehaviour
{
    static string nextScene;
    public Image loadingbar;

    //다른곳에서 호출 가능하게 만들어주는 메소드 
    public static void LoadScene(string sceneName) {
        nextScene = sceneName;
        SceneManager.LoadScene("Test1_Loading");
    
    }


    //씬만 로딩 가능하게 만들어줌 
    void Start()
    {
        StartCoroutine(LoadSceneLoadingBar());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //완전히 로딩가능하게 만들고 1초 페이크 로딩 만들기 
    IEnumerator LoadSceneLoadingBar() {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0f;
        while (!op.isDone) {
            yield return null;
            if (op.progress < 0.5f)
            {
                loadingbar.fillAmount = op.progress;
            }
            else {
                timer += Time.deltaTime;
                loadingbar.fillAmount = Mathf.Lerp(0.5f, 1f, timer);
                if (loadingbar.fillAmount >= 1f) {

                    op.allowSceneActivation = true;
                    yield break;
                }
            
            }
        
        }
    }
}
