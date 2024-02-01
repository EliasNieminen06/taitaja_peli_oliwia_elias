using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowWeaponScript : MonoBehaviour
{
    [SerializeField] GameObject arrowPF;
    [SerializeField] Transform arrowSpawnPoint;
    float reloadTime = 1.5f;
    float shotPower = 20f;
    bool canAttack = true;
    private void Start()
    {
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            StartCoroutine(shoot());
        }
    }
    IEnumerator shoot()
    {
        canAttack = false;

        // Instantiate arrow
        GameObject arrow = Instantiate(arrowPF, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
        Rigidbody arrowRigidbody = arrow.GetComponent<Rigidbody>();

        // Set the arrow velocity to maximum
        arrowRigidbody.velocity = arrowSpawnPoint.forward * shotPower;

        // Wait for reload time
        yield return new WaitForSeconds(reloadTime);

        canAttack = true;
    }
}
