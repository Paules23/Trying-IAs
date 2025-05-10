using UnityEngine;

public class AttackDamage : MonoBehaviour
{
    private int damageAmount;

    public void SetDamage(int damage)
    {
        damageAmount = damage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Destructible"))
        {
            if (other.TryGetComponent<DestructibleGemini>(out DestructibleGemini destructible))
            {
                destructible.TakeDamage(damageAmount);
            }
        }
    }
}