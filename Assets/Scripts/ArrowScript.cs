using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public int damage = 10;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyScript>().TakeDamage(damage);
        }
        Destroy(this.gameObject);
    }
}
