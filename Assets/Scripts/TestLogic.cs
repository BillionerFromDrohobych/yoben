using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class TestLogic : MonoBehaviour
{
    private string[] testData { get; set; }
    private string[] testOriginal { get; set; }
    private string[] testTranslate { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RequestfortheTest());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator RequestfortheTest()
    {
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("Login", PlayerPrefs.GetString("Login"));
        wwwForm.AddField("Command", "Test");
        wwwForm.AddField("RankTest", PlayerPrefs.GetInt("TestRank"));
        WWW www = new WWW("https://oldishere.000webhostapp.com/", wwwForm);
        yield return www;

        if (www.text == "")
        {
            Debug.Log("Internet problems");
        }
        else{
         Debug.Log(www.text);
        testData = www.text.Split('+');
        Debug.Log(testData[0]);
        Debug.Log(testData[1]);
        testOriginal = testData[0].Split(';');
        testTranslate = testData[1].Split(';');
        

        }
}
}
