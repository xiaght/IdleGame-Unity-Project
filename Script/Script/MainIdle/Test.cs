using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{

    public TextMeshProUGUI testText;

    private void Start()
    {
        testText.text = PlayerPrefs.GetString("ClickValue")+"  ";
        testText.text += PlayerPrefs.GetString("TokenArr") + "  ";
        testText.text += PlayerPrefs.GetString("Gold") + "  ";

    }





}
