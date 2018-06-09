using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using ForestGuard;

public class LoginController : MonoBehaviour {

    public static int State = -1;
    public static string Message = null;

    public GameObject loginPanel;
    public GameObject signupPanel;
    private string acct;
    private string psw;
    private string ncn;
    //private GameObject tempPrompt;
    public static PromptController promptCtrl = new PromptController();

    // Use this for initialization
    void Start ()
    {
        loginPanel = GameObject.Find("LoginPanel");
        signupPanel = GameObject.Find("SignupPanel");
        InputControler.Instance.LoginFirstSelected = GameObject.Find("AccountField").GetComponent<InputField>();
        InputControler.Instance.SignupFirstSelected = GameObject.Find("accountField").GetComponent<InputField>();
        InputControler.Instance.Login = GameObject.Find("Login").GetComponent<Button>();
        InputControler.Instance.Signup = GameObject.Find("SignUp").GetComponent<Button>();
        signupPanel.SetActive(false);
        InputControler.Instance.isLogin = true;
        Client.Instance.Run();
    }

    // Update is called once per frame
    void Update()
    {
        switch (State)
        {
            case 0:
                MessageShow(Message); break;
            case 1:
                JumpLoginPanel();break;
            case 2:
                SceneManager.LoadSceneAsync(1); break;
            default:
                return;
        }
        State = -1;
    }

    void OnApplicationQuit()
    {
       Client.Instance.Stop();
    }

    //public void SetLoginPanelVisible(bool visible)
    //{
    //    loginPanel.SetActive(visible);
    //}

    //public void SetSignupPanelVisible(bool visible)
    //{
    //    signupPanel.SetActive(visible);
    //}

    public void JumpLoginPanel()
    {
        Debug.Log("JumpLogin");
        loginPanel.SetActive(true);
        signupPanel.SetActive(false);
        //SetLoginPanelVisible(true);
        //SetSignupPanelVisible(false);
        InputControler.Instance.LoginFirstSelected.Select();
        InputControler.Instance.isLogin = true;
    }

    public  void JumpSignupPanel()
    {
        Debug.Log("JumpSignup");
        signupPanel.SetActive(true);
        loginPanel.SetActive(false);
        //SetSignupPanelVisible(true);
        //SetLoginPanelVisible(false);
        InputControler.Instance.SignupFirstSelected.Select();
        InputControler.Instance.isLogin = false;
    }

    public void OnLoginClick()
    {
        Debug.Log("login click");
        bool login = true;
        acct = GameObject.Find("AccountField").GetComponent<InputField>().text;
        psw = GameObject.Find("PasswordField").GetComponent<InputField>().text;

        //需重构成焦点转移后判定并提示
        if (String.IsNullOrEmpty(acct) || String.IsNullOrEmpty(psw))
        {
            login = false;
            MessageShow("输入栏不能为空");
            //UnityEditor.EditorUtility.DisplayDialog("Warning", "Input Field can't be empty", "Ok");
            GameObject.Find("PasswordField").GetComponent<InputField>().text = null;
        }

        if (login)
        {
            var info = new Account { Id = acct, Password = psw };
            Client.Instance.Send(RequestType.Login, Proto.Serialize(info));
            //SceneManager.LoadSceneAsync(1);
        }
    }

    public void OnSignupClick()
    {
        Debug.Log("Signup click");

        bool signUp = true;
        acct = GameObject.Find("accountField").GetComponent<InputField>().text;
        psw = GameObject.Find("passwordField").GetComponent<InputField>().text;
        ncn = GameObject.Find("nicknameField").GetComponent<InputField>().text;

        //需重构成焦点转移后判定并提示
        if (String.IsNullOrEmpty(acct) || String.IsNullOrEmpty(psw) || String.IsNullOrEmpty(ncn))
        {
            signUp = false;
            MessageShow("输入栏不能为空");
            //UnityEditor.EditorUtility.DisplayDialog("Warning", "Input Field can't be empty", "Ok");
        }
        else if(GameObject.Find("passwordAField").GetComponent<InputField>().text != psw)
        {
            signUp = false;
            MessageShow("两次密码输入不一致");
        }

        if (signUp)
        {
            var info = new UserInfo{ Account = acct, Password = psw, Nickname = ncn };
            Client.Instance.Send(RequestType.Regist, Proto.Serialize(info));
            ////注册成功返回登陆界面
            //if(UnityEditor.EditorUtility.DisplayDialog("Prompt", "Registration success", "Ok"))
            //{
            //    JumpLoginPanel();
            //}
        }
    }

    public void MessageShow(string msg)
    {
        promptCtrl.ShowPrompt(msg);
    }
}
