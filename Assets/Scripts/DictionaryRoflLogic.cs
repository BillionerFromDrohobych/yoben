using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DictionaryRoflLogic : MonoBehaviour
{
    private int LvlStartRank { get; set; }
    public RawImage rawImage;
    private int currentUser;
    public string SceneLoad;
    public Sprite spriteEndButton;
    
    // Start is called before the first frame update
    void Start()
    {
        LvlStartRank = PlayerPrefs.GetInt("LevelDictionaryBegin", 1);
        currentUser = LvlStartRank + 9;
        StartCoroutine(RequestForMem());
    }

    public void LoadMemButton()
    {
        if (LvlStartRank > currentUser)
        {
            SceneManager.LoadScene(SceneLoad);

        }

        else
        {

            LvlStartRank++;
            StartCoroutine(RequestForMem());
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (LvlStartRank > currentUser)
        {
            GameObject.Find("loadMemButton").GetComponentInChildren<Image>().overrideSprite = spriteEndButton;
            
            
        }


    }

    private IEnumerator RequestForMem()
    {            
        Debug.Log(LvlStartRank);

        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("Login", PlayerPrefs.GetString("Login"));
        wwwForm.AddField("Command", "Memes");
        wwwForm.AddField("RankForMem",LvlStartRank);
        WWW www = new WWW("https://oldishere.000webhostapp.com/",wwwForm);
        
        yield return www;
        rawImage.texture = www.texture;
    }
}
