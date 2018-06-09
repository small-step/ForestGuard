using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptController : MonoBehaviour {

    private GameObject tempPrompt;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void ShowPrompt(string msg)
    {
        if (tempPrompt == null)
        {
            tempPrompt = Instantiate(Resources.Load("UI/Prefabs/PromptPanel")) as GameObject;
            tempPrompt.GetComponent<Transform>().SetParent(GameObject.Find("Background").GetComponent<Transform>(), false);
            tempPrompt.GetComponentInChildren<Text>().text = msg;
        }
    }

    public void RemovePrompt()
    {
        DestroyImmediate(transform.gameObject);
    }

    public void ExitPromptConfirm()
    {
        this.RemovePrompt();
        Application.Quit();
    }
}
