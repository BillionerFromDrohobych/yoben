using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DictionaryRoflLogic : MonoBehaviour
{
    private int LvlStartRank { get; set; }
    public RawImage rawImage;
    private int currentUser;
    
    // Start is called before the first frame update
    void Start()
    {
        currentUser = 1;
        StartCoroutine(RequestForMem());
        LvlStartRank = PlayerPrefs.GetInt("LevelDictionaryBegin", 1);
    }

    public void LoadMemButton()
    {
        currentUser++;
        StartCoroutine(RequestForMem());
        

    }
    // Update is called once per frame
    void Update()
    {
        if (currentUser < 10)
        {
            
        }
            
    }

    private IEnumerator RequestForMem()
    {
        
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("Login", PlayerPrefs.GetString("Login"));
        wwwForm.AddField("Command", "Memes");
        WWW www = new WWW("https://oldishere.000webhostapp.com/",wwwForm);
        
        yield return www;
        rawImage.texture = www.texture;
    }
}
