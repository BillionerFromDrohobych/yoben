using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwoButtonsSceneScript : MonoBehaviour
{
    public Text mainText;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void SignUpButton()
    {
                Application.LoadLevel(2);

    }

    public void SignInButton()
    {
        Application.LoadLevel(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
