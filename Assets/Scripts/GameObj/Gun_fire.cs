using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_fire : MonoBehaviour {

    private float lifetime = 0.1f;

	// Use this for initialization
	void Start () {
        Destroy(gameObject,lifetime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
