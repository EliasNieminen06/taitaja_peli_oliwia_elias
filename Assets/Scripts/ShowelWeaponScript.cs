using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowelWeaponScript : MonoBehaviour
{
    [SerializeField] Animator anim;
    float attackCooldown = 1.0f;
    bool canAttack = true;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
        {
            StartCoroutine(attack());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!canAttack)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<EnemyScript>().TakeDamage(50);
            }
        }
    }
    IEnumerator attack()
    {
        canAttack = false;
        anim.SetTrigger("attack");

        yield return new WaitForSeconds(attackCooldown);

        canAttack = true;
    }
}
