using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputControler : MonoBehaviour {

    public static InputControler Instance = null;

    public InputField LoginFirstSelected;
    public InputField SignupFirstSelected;
    public Button Login;
    public Button Signup;
    public bool isLogin;
    //private GameObject tempHint;
    //private bool isfocused = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

    }

    // Use this for initialization
    void Start () {}

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable s = EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            Debug.Log(s);
            if (s.GetType() != typeof(InputField))
            {
                if(isLogin)
                {
                    s = LoginFirstSelected;
                }
                else
                {
                    s = SignupFirstSelected;
                }
            }
            s.Select();
        }
        if(Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            if(isLogin)
            {
                Login.onClick.Invoke();
            }
            else
            {
                Signup.onClick.Invoke();
            }
        }
        //if(LoginFirstSelected.isFocused == true)
        //{
        //    isfocused = true;
        //}
        //else
        //{
        //    if(isfocused == true)
        //    {
        //        isfocused = false;
        //        if (tempHint == null)
        //        {
        //            Debug.Log("do");
        //            tempHint = Instantiate(Resources.Load("UI/Prefabs/hint")) as GameObject;
        //            Debug.Log(tempHint);
        //            tempHint.GetComponent<Transform>().SetParent(GameObject.Find("AccountField").GetComponent<Transform>(), true);
        //            tempHint.GetComponent<Transform>().localPosition = new Vector3(0, -30, 0);
        //            tempHint.GetComponent<Text>().text = "两次密码输入不同";
        //        }
        //    }
        //}
    }

}
