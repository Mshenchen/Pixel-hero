using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiches : Enemy
{
    private float moveRate = 2.0f;
    private float moveTimer;
    public float minX, maxX, minY, maxY;
    private float shotRate = 2.1f;
    private float shotTimer;
    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        Attack();
    }
    protected override void Move()
    {
        RandomMove();
    }
    private void RandomMove()
    {
        moveTimer += Time.deltaTime;
        if (moveTimer > moveRate)
        {
            transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
            moveTimer = 0;
        }
    }
    protected override void Attack()
    {
        shotTimer += Time.deltaTime;
        if (shotTimer > shotRate)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            shotTimer = 0;
        }
    }
}

