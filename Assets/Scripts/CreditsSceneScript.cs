using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsSceneScript : MonoBehaviour
{
   public string SceneNameToBack;

   public void BackButton()
   {
      SceneManager.LoadScene(SceneNameToBack);
   }
}
