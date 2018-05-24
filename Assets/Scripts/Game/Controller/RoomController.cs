using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomController : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        var btns = GetComponentsInChildren<Button>();
        foreach(var btn in btns)
        {
            if(btn.name == "EnterGame")
            {
                btn.onClick.AddListener(EnterGame);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnterGame()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
