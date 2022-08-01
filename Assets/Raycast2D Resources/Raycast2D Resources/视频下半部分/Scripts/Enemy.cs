using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;
    private float healthPoint;
    [SerializeField] private float maxHealthPoint;
    protected Transform target;
    [SerializeField] protected float distance;
    private SpriteRenderer sp;
    void Start()
    {
        healthPoint = maxHealthPoint;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        TurnDirection();
        Attack();
    }
    private void FixedUpdate()
    {
        Move();
    }
    protected virtual void Move()
    {
        if (Vector2.Distance(transform.position, target.position) < distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position,moveSpeed*Time.deltaTime);
        }
        
    }
   protected virtual void TurnDirection()
    {
        if (transform.position.x > target.position.x)
        {
            sp.flipX = true;
        }
        else
        {
            sp.flipX = false;
        }
    }
    protected virtual void Death()
    {
        Destroy(gameObject);
    }
    protected virtual void Attack()
    {
    }
}
