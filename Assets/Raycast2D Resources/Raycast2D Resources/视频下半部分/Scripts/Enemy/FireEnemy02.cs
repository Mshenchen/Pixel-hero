using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemy02 : MonoBehaviour
{
    public Transform wayPoint01, wayPoint02;
    private Transform wayPointTarget;
    [SerializeField] private float moveSpeed;

    [SerializeField] private float attackRange;
    private Animator anim;//WALK & ATTACK Animation
    public GameObject projectile;
    public Transform firePoint;
    private Transform target;
    void Start()
    {
        wayPointTarget = wayPoint01;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (GetComponentInChildren<HealthBar>().currentHp <= 0)
        {
            //isDead = true;
            anim.SetBool("isDied", true);
            GetComponent<CircleCollider2D>().enabled = false;


            return;
        }

        if (Vector2.Distance(transform.position, target.position) >= attackRange)
        {
            anim.SetBool("isAttack", false);

            Patrol();
        }
        else
        {
            anim.SetBool("isAttack", true);
        }
    }
    private void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPointTarget.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, wayPoint01.position) < 0.01f)
        {
            wayPointTarget = wayPoint02;

            //sp.flipX = false
            TurnAround();
        }

        if (Vector2.Distance(transform.position, wayPoint02.position) < 0.01f)
        {
            wayPointTarget = wayPoint01;

            //sp.flipX = true
            TurnAround();
        }
    }
    private void TurnAround()
    {
        Vector3 localTemp = transform.localScale;
        localTemp.x *= -1;
        transform.localScale = localTemp;
    }
    public void Shot()
    {
        Instantiate(projectile, firePoint.position, Quaternion.identity);
    }
}
