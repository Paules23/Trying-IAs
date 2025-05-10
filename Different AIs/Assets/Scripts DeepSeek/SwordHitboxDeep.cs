using UnityEngine;

public class SwordHitboxDeep : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Destructible"))
        {
            Destroy(other.gameObject);
        }
    }
}