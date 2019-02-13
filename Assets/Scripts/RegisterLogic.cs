using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
using Debug = UnityEngine.Debug;

public class RegisterLogic : MonoBehaviour
{
    public InputField inputEmail;
    public InputField inputLogin;
    public InputField inputPassword;
    public Button buttonRegister;
    public Text textOutput;
    public ColorBlock colorBlock;
   
    private string reg = @"^[\P{L}\p{IsBasicLatin}]+$";


  
    // Start is called before the first frame update
    void Start()
    {
        buttonRegister.enabled = false;
        colorBlock = buttonRegister.colors;
        colorBlock.normalColor = Color.grey;
        buttonRegister.colors = colorBlock;

    }
    //react on click Register Button
    public void RegisterButton()
    {
        
        if (inputEmail.text.Length < 40)
        {
            if (inputLogin.text.Length < 10 && Regex.IsMatch(inputLogin.text, reg, RegexOptions.IgnoreCase)) 
            {
                if (inputPassword.text.Length < 10 && Regex.IsMatch(inputPassword.text, reg, RegexOptions.IgnoreCase))
                {
                    StartCoroutine(RequestRegister());

                }
                else
                {
                    textOutput.text = "password must contain only a-z and 1-9 and be shorter as 10";
                }
            }
            else
            {
                textOutput.text = "login must contain only a-z and 1-9 and be shorter as 10";
            }
        }
        else
        {
            textOutput.text = "email must be shorter";
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        if (inputEmail.text == "" || inputLogin.text == "" || inputPassword.text == "")
        {
            buttonRegister.enabled = false;
            colorBlock.normalColor = Color.grey;
            buttonRegister.colors = colorBlock;
        }
        else
        {
            colorBlock.normalColor = Color.white;
            buttonRegister.colors = colorBlock;
            buttonRegister.enabled = true;
        }
    }
    //Send request to the server for register
    private IEnumerator RequestRegister()
    {
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("Command","Register");
        wwwForm.AddField("Email",inputEmail.text);
        wwwForm.AddField("Login",inputLogin.text);
        wwwForm.AddField("Password",inputPassword.text);
        WWW www = new WWW("https://oldishere.000webhostapp.com/",wwwForm);
        yield return www;
        Debug.Log(www.error);
        //Obrabatue answer servera
        switch(www.text)
        {
            case "LoginError":
                textOutput.text = "This login is already exist";
                Debug.Log("This login is already exist");
                break;
            case "EmailInvalidError":
                textOutput.text = "Invalid email";
                Debug.Log("Invalid email");
                break;
            case "Registered":
                Debug.Log("User's register is successfully");
                PlayerPrefs.SetInt("LoginStatus", 1);
                PlayerPrefs.SetString("Login", inputLogin.text);
                PlayerPrefs.SetString("Password", inputPassword.text);
                Application.LoadLevel(4);
                break;
            case "EmailError":
                textOutput.text = "This email already exist";
                Debug.Log("This email already exist");
                break;
        }
    }
}
