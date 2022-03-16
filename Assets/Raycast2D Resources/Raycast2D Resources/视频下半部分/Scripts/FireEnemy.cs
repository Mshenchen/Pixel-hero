using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemy : MonoBehaviour
{
    public Transform TargetA,TargetB,Target;
    public float moveSpeed;
    public LineRenderer lineRenderer;
    public Gradient greenColor, redColor;
    public Transform firePoint;
    public float maxDist=20f;
    public LayerMask mask;
    public GameObject hitEffect;
    private Vector2 EndLine;
    void Start()
    {
        Target = TargetA;
        //firePoint = GetComponentInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Move();
        Detect();
    }
    private void Move()
    {
        if (Vector2.Distance(transform.position, TargetA.position) <= 0.01f)
        {
            Target = TargetB;
        }
        if (Vector2.Distance(transform.position, TargetB.position) <= 0.01f)
        {
            Target = TargetA;
        }
        transform.position = Vector2.MoveTowards(transform.position, Target.position,moveSpeed*Time.deltaTime);
    }
    private void Detect()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(firePoint.position, -transform.right, maxDist, mask);
        //如果射线碰到物体
        if (hitinfo.collider!= null)
        {
            lineRenderer.SetPosition(1, firePoint.position);
            if (hitinfo.collider.tag=="Block")
            {
                lineRenderer.SetPosition(0, hitinfo.point);
                lineRenderer.colorGradient = greenColor;
            }
            if (hitinfo.collider.tag == "Player")
            {
                lineRenderer.SetPosition(0, hitinfo.point);
                lineRenderer.colorGradient = redColor;
                StartCoroutine("isAttack");
                CameraController.instance.isShack=true;
                CameraController.instance.ShackCamera(0.2f);
            }
            Instantiate(hitEffect, hitinfo.point, Quaternion.identity);

        }
        //如果射线没有碰到物体
        if (hitinfo.collider == null)
        {
            //射线终点
            EndLine = new Vector2(firePoint.position.x - maxDist, firePoint.position.y);
            lineRenderer.SetPosition(1, firePoint.position);
            lineRenderer.colorGradient = greenColor;
            lineRenderer.SetPosition(0, EndLine);
        }
    }
    IEnumerator isAttack()
    {
        yield return new WaitForEndOfFrame();
        GameObject.FindGameObjectWithTag("Health").GetComponent<PlayerHp>().playercurrentHp -= 10f;
    }
}
