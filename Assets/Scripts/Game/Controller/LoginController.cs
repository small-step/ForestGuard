using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using World;

public class LoginController : MonoBehaviour {

    private GameObject loginPanel;
    private GameObject signupPanel;
    private string acct;
    private string psw;
    private string ncn;

    // Use this for initialization
    void Start () {
        loginPanel = GameObject.Find("LoginPanel");
        signupPanel = GameObject.Find("SignupPanel");
        signupPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void SetLoginPanelVisible(bool visible)
    {
        loginPanel.SetActive(visible);
    }

    public void SetSignupPanelVisible(bool visible)
    {
        signupPanel.SetActive(visible);
    }

    public void JumpLoginPanel()
    {
        Debug.Log("JumpLogin");
        SetLoginPanelVisible(true);
        SetSignupPanelVisible(false);
        //loginPanel.SetActive(true);
        //signupPanel.SetActive(false);
    }

    public  void JumpSignupPanel()
    {
        Debug.Log("JumpSignup");
        SetSignupPanelVisible(true);
        SetLoginPanelVisible(false);
        //signupPanel.SetActive(true);
        //loginPanel.SetActive(false);
    }

    public void Login()
    {
        Debug.Log("login click");

        bool login = true;
        acct = GameObject.Find("AccountField").GetComponent<InputField>().text;
        psw = GameObject.Find("PasswordField").GetComponent<InputField>().text;

        if (String.IsNullOrEmpty(acct) || String.IsNullOrEmpty(psw))
        {
            login = false;
            UnityEditor.EditorUtility.DisplayDialog("Warning", "Input Field can't be empty", "Ok");
            GameObject.Find("PasswordField").GetComponent<InputField>().text = null;
        }

        if (login)
        {
            var usr = new Account{ ID = acct, Password = psw };
            Client.Instance.Send(RequestType.Login, Proto.Serialize(usr));
            SceneManager.LoadSceneAsync(1);
        }
    }

    public void SignUP()
    {
        Debug.Log("Signup click");

        bool signUp = true;
        acct = GameObject.Find("accountField").GetComponent<InputField>().text;
        psw = GameObject.Find("passwordField").GetComponent<InputField>().text;
        ncn = GameObject.Find("nicknameField").GetComponent<InputField>().text;

        if (String.IsNullOrEmpty(acct) || String.IsNullOrEmpty(psw) || String.IsNullOrEmpty(ncn))
        {
            signUp = false;
            UnityEditor.EditorUtility.DisplayDialog("Warning", "Input Field can't be empty", "Ok");
        }

        if (signUp)
        {
            var info = new UserInfo{ Account = acct, Password = psw, Nickname = ncn };
            var data = Proto.Serialize(info);
            Client.Instance.Send(RequestType.Regist, data);
            //注册成功返回登陆界面
            if(UnityEditor.EditorUtility.DisplayDialog("Prompt", "Registration success", "Ok"))
            {
                JumpLoginPanel();
            }
        }
    }
}
