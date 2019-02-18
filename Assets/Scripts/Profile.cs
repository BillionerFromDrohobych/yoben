using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.U2D;
//using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Profile : MonoBehaviour
{
    public Image runbar;
    public Text dictionaryrankfield;
    public Image runbar1;
    public Text grammaryrankfield1;
    public Text loginText;
    public string SceneNameToGo;    
    public string SceneNameToLogOut;    
    private float currentDictionary { get; set; }
    private float currentGrammary { get; set; }

    public float speed;
    private WWW www;
    private string[] serverDictionatyRank; //0 - dictionaryRank , 1 - grammaryRank
    void Start()
    {
        StartCoroutine(RequestforRank());
        
        currentGrammary = 0;
        currentDictionary = 0;
        loginText.text = PlayerPrefs.GetString("Login");
        
    }

    public void MenuLevel()
    {
        SceneManager.LoadScene(SceneNameToGo);
    }
   

    // Update is called once per frame
    void Update()
    {
       if (currentDictionary <= float.Parse(serverDictionatyRank[0]))
        {
            currentDictionary += speed * Time.deltaTime;
        }
       if (currentGrammary <= float.Parse(serverDictionatyRank[0]))
       {
           currentGrammary += speed * Time.deltaTime;
       }
               

        runbar.GetComponent<Image>().fillAmount = currentDictionary / 100;
        runbar1.GetComponent<Image>().fillAmount = currentGrammary / 100;
    }

    public void LogoutButton()
    {
        PlayerPrefs.SetInt("LoginStatus", 0);
        SceneManager.LoadScene(SceneNameToLogOut);
            
    }

    private IEnumerator RequestforRank()
    {
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("Login", PlayerPrefs.GetString("Login"));
        wwwForm.AddField("Command", "Rank");
        www = new WWW("https://oldishere.000webhostapp.com/",wwwForm);
        yield return www;
        if (www.text == "")
        {
           Debug.Log("Internet problems"); 
        }
        else
        {
            serverDictionatyRank = www.text.Split(';');
            Debug.Log(www.text);
            Debug.Log(serverDictionatyRank[0]);
            dictionaryrankfield.text = serverDictionatyRank[0]+"%";
            //grammaryrankfield1.text = serverDictionatyRank[1]+"%";
        }
    }
}
