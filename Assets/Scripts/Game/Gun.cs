using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    private const string Path = "Characters/Chevalier/Prefabs/Gun_fire";
    public float Force = 1000f;
    private Vector2 currentPosition;
    private SpriteRenderer spriteR;
    private float angle;
    private GameObject gunType;


    // Use this for initialization
    void Start() {
        currentPosition = transform.parent.position;
        spriteR = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {

        if (!spriteR)
        {
            return;
            Debug.Log("error");
        }

        //TODO gunTpye
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            spriteR.sprite = Resources.Load<Sprite>("Models/Gun1");//TODO gunTpye
            transform.position = new Vector2(transform.parent.position.x + 0.25f, transform.position.y);

            angle = Mathf.Atan2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
            //Debug.Log(angle); 
            transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg);
        }
        else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            spriteR.sprite = Resources.Load<Sprite>("Models/Gun0");
            transform.position = new Vector2(transform.parent.position.x - 0.25f, transform.position.y);

            angle = Mathf.Atan2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
            //Debug.Log(angle); 
            transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg +180);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            
        }


        if (/*checkFire() && */Input.GetKeyDown(KeyCode.J))               //可以发射子弹时间
        {
            //nextFire = Time.time + fireRate;
            fire();
            GameObject bullet = BulletsPool.bulletsPoolInstance.GetPooledObject();//获取对象池中的子弹
            GameObject gunPos = GameObject.Find("Gun_Position");

            if (bullet != null)//不为空时执行
            {
                bullet.SetActive(true);//激活子弹
                if (GameObject.Find("Gun").GetComponent<SpriteRenderer>().sprite.name.Equals("Gun0"))
                {
                    bullet.transform.position = gunPos.transform.position;//初始化子弹的位置
                    bullet.GetComponent<Rigidbody2D>().AddForce(-transform.right * Force);//TODO
                }
                else if (GameObject.Find("Gun").GetComponent<SpriteRenderer>().sprite.name.Equals("Gun1"))
                {
                    bullet.transform.position = gunPos.transform.position;//初始化子弹的位置
                    bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * Force);//TODO
                }
            }
        }
    }

    

    public void fire()
    {
       
        if (spriteR.sprite.name.Equals("Gun1"))
        {
            GameObject gun_fire = (GameObject)Resources.Load(path: Path);
            SpriteRenderer fire = gun_fire.GetComponent<SpriteRenderer>();
            fire.sprite = Resources.Load<Sprite>("Effects/Boom/boom");
            gun_fire = Instantiate(gun_fire);
            gun_fire.transform.parent = this.transform;
            gun_fire.transform.position = new Vector2(transform.position.x, transform.position.y);
            gun_fire.transform.localPosition = new Vector2(0.65f,0.2f);
            gun_fire.transform.localRotation = Quaternion.identity;
        }

        else if(spriteR.sprite.name.Equals("Gun0"))
        {
            GameObject gun_fire = (GameObject)Resources.Load(path: Path);
            SpriteRenderer fire = gun_fire.GetComponent<SpriteRenderer>();
            fire.sprite = Resources.Load<Sprite>("Effects/Boom/boom");
            gun_fire = Instantiate(gun_fire);
            gun_fire.transform.parent = this.transform;
            gun_fire.transform.position = new Vector2(transform.position.x, transform.position.y);
            gun_fire.transform.localPosition = new Vector2(-0.65f, 0.15f);
            gun_fire.transform.localRotation = Quaternion.identity;
        }
    }

    public float currentFireTime;
    public float fireRate = .2f;

    public bool checkFire()
    {
        currentFireTime += Time.deltaTime;
        if (currentFireTime >= fireRate)
        {
            currentFireTime = 0;
            return true;
        }
        return false;
    }
}