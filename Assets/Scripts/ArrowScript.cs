using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
