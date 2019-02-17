using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DictionaryLevelScript : MonoBehaviour
{
    private string[] currentUserRank { get; set; }
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string sceneToBack;

    private WWW www;
    private int current;

    public Button level1Button;
    public Button level2Button;
    public Button level3Button;
    public Button level4Button;
    public Button level5Button;
    public Button testButton;

    void Start()
    {
        StartCoroutine(RankRequest());
    }

    void Update()
    {
       /* if (current > 11)
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

        if (current > 41)
        {
            level5Button.enabled = true;
        }
        else
        {
            level5Button.enabled = false;
        }*/

        testButton.enabled = true;
        level1Button.enabled = true;
    }

    public void backButton()
    {
        SceneManager.LoadScene(sceneToBack);
    }

    public void Level1()
    {
        Debug.Log("sa");
        PlayerPrefs.SetInt("LevelDictionaryBegin", 1);
        SceneManager.LoadScene(sceneToLoad);
    }

    public void Level2()
    {
        PlayerPrefs.SetInt("LevelDictionaryBegin", 11);
        SceneManager.LoadScene(sceneToLoad);
    }

    public void Level3()
    {
        PlayerPrefs.SetInt("LevelDictionaryBegin", 21);
        SceneManager.LoadScene(sceneToLoad);
    }

    public void Level4()
    {
        PlayerPrefs.SetInt("LevelDictionaryBegin", 31);
        SceneManager.LoadScene(sceneToLoad);
    }

    public void Level5()
    {
        PlayerPrefs.SetInt("LevelDictionaryBegin", 41);
        SceneManager.LoadScene(sceneToLoad);
    }

    public void TestButton()
    {
        PlayerPrefs.SetInt("TestRank", 1);
        Application.LoadLevel(8);
    }
    


    private IEnumerator RankRequest()
    {
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("Login", PlayerPrefs.GetString("Login"));
        wwwForm.AddField("Command", "Rank");
        www = new WWW("https://oldishere.000webhostapp.com/", wwwForm);
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