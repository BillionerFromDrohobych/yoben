using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignInSceneScript : MonoBehaviour
{
    public InputField login_Input;

    public InputField passwod_Input;

    public Button buttonSign;

    public ColorBlock colorblockSign;
    // Start is called before the first frame update
    void Start()
    {
        buttonSign.enabled = false;
        colorblockSign = buttonSign.colors;
        colorblockSign.normalColor = Color.grey;
        buttonSign.colors = colorblockSign;
    }

    public void SignInButton()
    {
        Application.LoadLevel(3);
    }

    public void BackButton()
    {
        Application.LoadLevel(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (login_Input.text == "" || passwod_Input.text == "")
        {
            buttonSign.enabled = false;
            colorblockSign.normalColor = Color.grey;
            buttonSign.colors = colorblockSign;


        }
        else
        {
            buttonSign.enabled = true;
            colorblockSign.normalColor = Color.white;
            buttonSign.colors = colorblockSign;    
        }
    }
}
