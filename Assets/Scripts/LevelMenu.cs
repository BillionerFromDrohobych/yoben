using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private string[] currentUserRank { get; set; }
    [SerializeField] private string sceneToLoad;
    private WWW www;
    private int current;
        
    public Button level1Button;
    public Button level2Button;
    public Button level3Button;
    public Button level4Button;

    void Start()
    {
        
        StartCoroutine(RankRequest());
        


    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (current > 11)
        {
            level2Button.enabled = true;
        }
        else
        {
            level2Button.enabled = false;
 
        }

        if (current > 21)
        {
            level3Button.enabled = true;

        }
        else
        {
           level3Button.enabled = false;

        }

        if (current > 31)
        {
            level4Button.enabled = true;
        }
        else
        {
            level4Button.enabled = false;
   
        }
    }

    public void level1()
    {
        
        PlayerPrefs.SetInt("LevelDictionaryBegin", 1);
        SceneManager.LoadScene(sceneToLoad);
    }
    public void level2()
    {
        PlayerPrefs.SetInt("LevelDictionaryBegin", 11);
        SceneManager.LoadScene(sceneToLoad);
    }
    public void level3()
    {
        PlayerPrefs.SetInt("LevelDictionaryBegin", 21);
        SceneManager.LoadScene(sceneToLoad);
    }
    public void level4()
    {
        PlayerPrefs.SetInt("LevelDictionaryBegin", 31);
        SceneManager.LoadScene(sceneToLoad);
    }

    private IEnumerator RankRequest()
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
            currentUserRank = www.text.Split(';');
            current = Convert.ToInt32(currentUserRank[0]);

            
           
        }
    }
}
