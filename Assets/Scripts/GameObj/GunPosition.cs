using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class GunPosition : MonoBehaviour {
 
     private Vector2 gunPos;
     private GameObject gunObj;
 
 	// Use this for initialization
 	void Start () {
         gunObj = GameObject.FindGameObjectWithTag("Gun");
         gunPos = gunObj.transform.position;
         this.transform.parent = gunObj.transform;
 	}
 	
 	// Update is called once per frame
 	void Update () {
         if (!gunObj)
         {
             Debug.Log("Gun is null");
         }
 
         if(gunObj.GetComponent<SpriteRenderer>().sprite.name == "Gun1")
         {
             this.transform.position = gunPos;
                
             this.transform.localPosition = new Vector2(0.65f, 0f);
         }
         else if(gunObj.GetComponent<SpriteRenderer>().sprite.name == "Gun0")
         {
             this.transform.position = gunPos;
             
             this.transform.localPosition = new Vector2(-0.65f, 0f);
         }
 
         
 
 	}
 }