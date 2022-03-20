using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D boxCollider;
    private bool isDead;

    public GameObject slashEffect;
    private hatchet hatchet;
    void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        hatchet = GameObject.FindGameObjectWithTag("Hatchet").GetComponent<hatchet>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Hatchet" && hatchet.isDamage)
        {
            isDead = true;//MARKER Making sure our weapon will not damage this item again
            boxCollider.enabled = false;

            anim.SetTrigger("isDestroyed");


            Instantiate(slashEffect, transform.position, Quaternion.identity);//Make one slash visual effect
        }
    }
}
