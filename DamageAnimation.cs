using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAnimation : MonoBehaviour
{
    public PlayerController playerController;
    public Damage damage;
    public int teamId = 0;
    public int damageAmount = 1;
    public bool destroyAfterDamage = true;
    public bool dealDamageOnTriggerEnter = false;
    public bool dealDamageOnTriggerStay = false;
    public bool dealDamageOnCollision = false;
    public Animator animator;

    // Comment for commit //
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && dealDamageOnTriggerEnter)
        {
            DealDamage(collision.gameObject);
            animator.SetTrigger("isDamaged");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (dealDamageOnTriggerStay)
        {
            DealDamage(collision.gameObject);
            animator.SetTrigger("isDamaged");
        }
    }

    private void DealDamage(GameObject collisionGameObject)
    {
        Health collidedHealth = collisionGameObject.GetComponent<Health>();
        if (collidedHealth != null)
        {
            if (collidedHealth.teamId != 1)
            {
                collidedHealth.TakeDamage(damageAmount);
                if (destroyAfterDamage)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }

}
