using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bats : Enemy
{
    public Transform wayPoint01,wayPoint02;
    public Transform wayPointTarget;
    private void Awake()
    {
        wayPointTarget = wayPoint01;
    }

    // Update is called once per frame
    protected override void Move()
    {
        base.Move();
        if (Vector2.Distance(transform.position, target.position) > distance)
        {
            if (Vector2.Distance(transform.position, wayPoint01.position) <0.01f)
            {
                wayPointTarget = wayPoint02;
            }
            if (Vector2.Distance(transform.position, wayPoint02.position) < 0.01f)
            {
                wayPointTarget = wayPoint01;
            }
            transform.position = Vector2.MoveTowards(transform.position, wayPointTarget.position, moveSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Invoke("isAttack", 0.5f);

        }
        
    }
    private void isAttack()
    {
        GameObject.FindGameObjectWithTag("Health").GetComponent<PlayerHp>().playercurrentHp -= 3.0f;
        Debug.Log("23");
    }
        
            
}
