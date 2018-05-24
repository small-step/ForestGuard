using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private float lifetime = 2f;
    private float  bulletDamage;//TODO gunType

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(DestroyWeapon(gameObject, lifetime));
    }

    void Update()
    {
        
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "backgroundCollider"){
            if (this.gameObject.activeSelf)
        {
            this.gameObject.SetActive(false);
        }
        }
    }

    private IEnumerator DestroyWeapon(GameObject obj, float desTime)
    {
        yield return new WaitForSeconds(desTime > 0 ? desTime : 0);
        if (obj.activeSelf)
        {
            obj.SetActive(false);
        }
    }
}
