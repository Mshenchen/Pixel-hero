using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject boomEffect;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Instantiate(boomEffect, transform.position, Quaternion.identity);
            other.gameObject.GetComponentInChildren<HealthBar>().currentHp -= 10;
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Block")
        {
            Instantiate(boomEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


}
