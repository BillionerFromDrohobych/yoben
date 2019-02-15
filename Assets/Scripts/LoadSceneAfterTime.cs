using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAfterTime : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoading = 2.0f;
    [SerializeField]
    private string sceneNameToLoad;
    [SerializeField]
    private string sceneNameToReisterLoad;
    private float timeElapsed;


    
    void Update()
    {
       
            timeElapsed += Time.deltaTime;


        
        
        if (timeElapsed > delayBeforeLoading)
        {
           
           if (PlayerPrefs.GetInt("LoginStatus") == 0)
            {
                SceneManager.LoadScene(sceneNameToLoad);
            }
            else
           {
               SceneManager.LoadScene(sceneNameToReisterLoad);
           }
        }
    }
}