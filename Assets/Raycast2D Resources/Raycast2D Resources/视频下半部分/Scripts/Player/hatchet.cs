using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hatchet : MonoBehaviour
{
    [SerializeField] private float rotateSpeed; //斧子旋转速度
    [SerializeField] private float moveSpeed;
    private Vector3 targetPos;
    private bool isClicked;
    private bool isRotating;
    private Transform playerTrans;//Weapon Return Position
    private bool canComeBack;//default is false
    private bool returnWeapon;
    private bool isDamage;
    private TrailRenderer tr;
    void Start()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        tr = GetComponentInChildren<TrailRenderer>();
        tr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        SelfRotation();
        if (Input.GetMouseButtonDown(0) && isClicked == false)
        {
            isClicked = true;
            targetPos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        }
        if (isClicked)
        {
            ThrowWeapon();
        }
        ReachAtMousePositon();
        if (Input.GetMouseButtonDown(0) && canComeBack)
        {
            isDamage = true;
            returnWeapon = true;
        }
        if (returnWeapon)
        {
            BackWeapon();
        }
        ReachAtPlayerPosition();
        if (!isClicked && !returnWeapon && !canComeBack)
        {
            transform.position = playerTrans.position;
        }
    }
    private void ReachAtMousePositon()
    {
        if (Vector2.Distance(targetPos, transform.position) <= 0.01f)
        {
            isRotating = false;
            isDamage = false;
            canComeBack = true;
            tr.enabled = false;
        }
    }
    private void ReachAtPlayerPosition()
    {
        if (Vector2.Distance(transform.position, playerTrans.position) <= 0.01f)
        {
            isRotating = false;
            isDamage = false;
            isClicked = false;
            canComeBack = false;
            returnWeapon = false;
            transform.rotation = new Quaternion(0, 0, 0, 0);
            tr.enabled = false;
        }
    }
    private void ThrowWeapon()
    {
        isRotating = true;
        isDamage = true;
        tr.enabled = true;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
    private void BackWeapon()
    {
        isRotating = true;
        tr.enabled = true;
        transform.position = Vector2.MoveTowards(transform.position, playerTrans.position, moveSpeed * 5 * Time.deltaTime);
    }
    private void SelfRotation()
    {
        if (isRotating)//STEP 02
        {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);//STEP 01 Weapon Rotation
        }
        else
        {
            transform.Rotate(0, 0, 0);
        }
    }
}
