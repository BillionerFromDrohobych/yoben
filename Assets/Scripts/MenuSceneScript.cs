using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneScript : MonoBehaviour
{
    public string sceneDictionary;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GrammatikButton()
    {
        Debug.Log("Gramatik opened");
    }

    public void DictionaryButton()
    {
        SceneManager.LoadScene(sceneDictionary);
        Debug.Log("Dictionary opened");
    }

    public void ProfileButton()
    {
        Application.LoadLevel(5);
        Debug.Log("Profile opened");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
