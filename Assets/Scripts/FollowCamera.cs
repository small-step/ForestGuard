using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    Vector3 offset;
    // Use this for initialization
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
        Rotate();
        Scale();
    }
    //缩放
    private void Scale()
    {
        float dis = offset.magnitude;
        dis += Input.GetAxis("Mouse ScrollWheel") * 5;
        Debug.Log("dis=" + dis);
        if (dis < 10 || dis > 40)
        {
            return;
        }
        offset = offset.normalized * dis;
    }
    //左右上下移动
    private void Rotate()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 pos = transform.position;
            Vector3 rot = transform.eulerAngles;

            //围绕原点旋转，也可以将Vector3.zero改为 target.position,就是围绕观察对象旋转
            transform.RotateAround(Vector3.zero, Vector3.up, Input.GetAxis("Mouse X") * 10);
            transform.RotateAround(Vector3.zero, Vector3.left, Input.GetAxis("Mouse Y") * 10);
            float x = transform.eulerAngles.x;
            float y = transform.eulerAngles.y;
            Debug.Log("x=" + x);
            Debug.Log("y=" + y);
            //控制移动范围
            if (x < 20 || x > 45 || y < 0 || y > 40)
            {
                transform.position = pos;
                transform.eulerAngles = rot;
            }
            //  更新相对差值
            offset = transform.position - target.position;
        }

    }
}
