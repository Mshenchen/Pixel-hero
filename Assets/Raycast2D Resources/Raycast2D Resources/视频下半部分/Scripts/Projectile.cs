using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform target;
    public float shotSpeed;
    private float maxLife = 2.0f;
    public GameObject destoryEffect;
    private float lifeBtwTimer;
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, shotSpeed * Time.deltaTime);
        lifeBtwTimer += Time.deltaTime;
        if (lifeBtwTimer >= maxLife)
        {
            Instantiate(destoryEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Instantiate(destoryEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
