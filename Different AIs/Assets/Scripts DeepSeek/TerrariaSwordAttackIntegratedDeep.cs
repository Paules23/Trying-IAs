using UnityEngine;
using System.Collections;

public class TerrariaSwordAttackIntegratedDeep : MonoBehaviour
{
    [Header("Sword References")]
    [SerializeField] private Transform swordPivot; // Asigna el objeto vacío (SwordPivot)
    [SerializeField] private Collider2D swordCollider;

    [Header("Attack Settings")]
    [SerializeField] private float attackAngle = 30f; // Ángulo total del ataque
    [SerializeField] private float attackDuration = 0.2f;
    [SerializeField] private KeyCode attackKey = KeyCode.Space;

    private bool isAttacking = false;
    private Quaternion originalRotation;

    private void Start()
    {
        originalRotation = swordPivot.localRotation; // Usa localRotation
        swordCollider.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(attackKey) && !isAttacking)
        {
            Attack();
        }
    }

    private void Attack()
    {
        Debug.Log("Attack Starts");
        isAttacking = true;
        swordCollider.enabled = true;

        // Rotación inicial (arriba)
        swordPivot.localRotation = originalRotation * Quaternion.Euler(0, 0, attackAngle);

        // Animación con corrutina
        StartCoroutine(AttackAnimation());
    }

    private IEnumerator AttackAnimation()
    {
        float timer = 0;
        Quaternion startRotation = swordPivot.localRotation;
        Quaternion endRotation = originalRotation * Quaternion.Euler(0, 0, -attackAngle);

        while (timer < attackDuration)
        {
            swordPivot.localRotation = Quaternion.Lerp(startRotation, endRotation, timer / attackDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        EndAttack();
    }

    private void EndAttack()
    {
        swordPivot.localRotation = originalRotation;
        swordCollider.enabled = false;
        isAttacking = false;
    }

    public void DestroyObject(GameObject obj)
    {
        if (obj.CompareTag("Destructible"))
        {
            Destroy(obj);
        }
    }
}