using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private Vector3 cursorPos;

    private void Update()
    {
        //将屏幕坐标系中【鼠标的像素点位置】转换为【世界坐 cursorPos】
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = cursorPos;//CORE WRONG
        transform.position = new Vector3(cursorPos.x, cursorPos.y,0);
    }


}
