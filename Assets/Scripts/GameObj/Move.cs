using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Animator animator;
    private Vector2 currentvector;
    private int currentValue;
    private int IdleValue = 3;
    public float speed = 10.00f;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!animator)
        {
            return;
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal"); //A D 左右
        float vertical = Input.GetAxis("Vertical"); //W S 上 下

        transform.Translate(Vector3.up * vertical * speed * Time.deltaTime);//W S 上 下
        transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);//A D 左右

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetInteger("animation", 2);
            currentValue = 2;
        }
        else if(Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetInteger("animation", 4);
            currentValue = 4;
        }
        else if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if((IdleValue == 3 && horizontal == 0) && currentValue == 4)
            {
                animator.SetInteger("animation", 4);
                currentValue = 4;
            }
            else if((IdleValue == 1 && horizontal == 0) && currentValue == 2)
            {
                animator.SetInteger("animation", 2);
                currentValue = 2;
            }
        }
        else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if((IdleValue == 3 && horizontal == 0) && currentValue == 4)
            {
                animator.SetInteger("animation", 4);
                currentValue = 4;
            }
            else if((IdleValue == 1 && horizontal == 0) && currentValue == 2)
            {
                animator.SetInteger("animation", 2);
                currentValue = 2;
            }
        }
        else if (horizontal == 0 && vertical == 0)
        {
            if(currentValue == 4)
            {
                animator.SetInteger("animation", 3);
                IdleValue = 3;
            }
            else if(currentValue == 2)
            {
                animator.SetInteger("animation", 1);
                IdleValue = 1;
            }
        }
    }

}