using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private float lifetime = 2f;

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

    private IEnumerator DestroyWeapon(GameObject obj, float desTime)
    {
        yield return new WaitForSeconds(desTime > 0 ? desTime : 0);
        if (obj.activeSelf)
        {
            obj.SetActive(false);
        }
    }
}
