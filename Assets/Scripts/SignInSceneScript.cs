using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignInSceneScript : MonoBehaviour
{
    public InputField login_Input;

    public InputField password_Input;

    public Button buttonSign;

    public ColorBlock colorblockSign;

    public Text textServer;

    private int hash { get; set; }
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
        StartCoroutine(LoginRequest());
    }

    public void BackButton()
    {
        Application.LoadLevel(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (login_Input.text == "" || password_Input.text == "")
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
    //Send login request to server
    private IEnumerator LoginRequest(){
        WWWForm wwwForm = new WWWForm();
        hash = password_Input.text.GetHashCode();
        wwwForm.AddField("Command", "Login");
        wwwForm.AddField("Login", login_Input.text);
        wwwForm.AddField("Password", hash);
        WWW www = new WWW("https://oldishere.000webhostapp.com/",wwwForm);
        yield return www;
        Debug.Log(www.error);
        //Obrabatue answer servera
        switch (www.text)
        {
            case "Success":
                PlayerPrefs.SetInt("LoginStatus",1);
                PlayerPrefs.SetString("Login", login_Input.text);
                PlayerPrefs.SetString("Password", password_Input.text);

                Application.LoadLevel(4);
                break;
            case "Login is not exist":
                textServer.text = "Login is not exist";
                Debug.Log("Login is not exist");
                break;
            case "Password is wrong":
                textServer.text = "Password is wrong";
                Debug.Log("Password is wrong");
                break;
            case "":
                textServer.text = "Problem with Internet Connection";
                break;
        }
       
    }
    
}
