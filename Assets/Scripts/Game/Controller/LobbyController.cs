using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using ForestGuard;

public class LobbyController : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        var btns = GetComponentsInChildren<Button>();
        foreach(var btn in btns)
        {
            if (btn.name == "Create")
            {
                btn.onClick.AddListener(CreateRoom);
            }
            else if(btn.name == "Enter")
            {
                btn.onClick.AddListener(QuickEnter);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateRoom()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void QuickEnter()
    {
        Client.Instance.Send(RequestType.MaxType, new byte [0]);
    }

    public void FetchRoomList()
    {

    }

}
