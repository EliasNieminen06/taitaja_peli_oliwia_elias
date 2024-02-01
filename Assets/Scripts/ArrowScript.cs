using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyScript>().TakeDamage(20);
        }
        Destroy(this.gameObject);
    }
}
