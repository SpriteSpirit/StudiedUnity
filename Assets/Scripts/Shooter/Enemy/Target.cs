using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float amount)
    {
        if (amount <= health)
        {
            amount = health;
        }
        
        health -= amount;
        animator.SetTrigger("GetHit");

        if (health <= 0)
        {
            animator.SetTrigger("Death");
            Invoke("Die", 3f);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
