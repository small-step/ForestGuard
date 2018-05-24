using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class GunPosition : MonoBehaviour {
 
     private Vector2 gunPos;
     private GameObject gunObj;
 
 	// Use this for initialization
 	void Start () {
         gunObj = GameObject.Find("Gun");
         gunPos = gunObj.transform.position;
         this.transform.parent = gunObj.transform;
 	}
 	
 	// Update is called once per frame
 	void Update () {
         if (!gunObj)
         {
             Debug.Log("Gun is null");
             return;
         }
 
         if(gunObj.GetComponent<SpriteRenderer>().sprite.name == "Gun1")
         {
             this.transform.position = gunPos;
             this.transform.localRotation = gunObj.transform.rotation;
             this.transform.localPosition = new Vector2(0.65f, 0.2f);
         }
         else if(gunObj.GetComponent<SpriteRenderer>().sprite.name == "Gun0")
         {
             this.transform.position = gunPos;
             this.transform.localRotation = gunObj.transform.rotation;
             this.transform.localPosition = new Vector2(-0.65f, 0.2f);
         }
 
         
 
 	}
 }