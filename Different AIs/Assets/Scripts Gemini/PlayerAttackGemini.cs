using UnityEngine;

public class PlayerAttackGemini : MonoBehaviour
{
    [SerializeField] private GameObject attackPrefab;
    [SerializeField] private Transform attackSpawnPoint;
    [SerializeField] private float attackDuration = 0.2f;
    [SerializeField] private float attackSpeed = 10f;
    [SerializeField] private int attackDamage = 1;
    [SerializeField] private KeyCode attackKey = KeyCode.Space;

    private bool isAttacking = false;
    private GameObject currentAttack;
    private float attackTimer;
    private int facingDirection = 1; // 1 para derecha, -1 para izquierda

    private PlayerMovementGemini playerMovement; // Referencia al script de movimiento

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovementGemini>();
        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement script not found on the same GameObject!");
        }
    }

    private void Update()
    {
        // Actualizar la dirección del ataque basada en el movimiento del jugador (si lo tienes)
        if (playerMovement != null)
        {
            if (playerMovement.GetHorizontalInput() > 0)
            {
                facingDirection = 1;
            }
            else if (playerMovement.GetHorizontalInput() < 0)
            {
                facingDirection = -1;
            }
        }

        if (Input.GetKeyDown(attackKey) && !isAttacking)
        {
            StartAttack();
        }

        if (isAttacking)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackDuration)
            {
                EndAttack();
            }
        }
    }

    private void StartAttack()
    {
        isAttacking = true;
        attackTimer = 0f;
        currentAttack = Instantiate(attackPrefab, attackSpawnPoint.position, attackSpawnPoint.rotation);
        Rigidbody2D attackRb = currentAttack.GetComponent<Rigidbody2D>();
        if (attackRb != null)
        {
            attackRb.velocity = new Vector2(facingDirection * attackSpeed, 0f);
        }

        // Si el ataque tiene un script de daño, le pasamos la información
        if (currentAttack.TryGetComponent<AttackDamage>(out AttackDamage damageScript))
        {
            damageScript.SetDamage(attackDamage);
        }
    }

    private void EndAttack()
    {
        isAttacking = false;
        if (currentAttack != null)
        {
            Destroy(currentAttack);
        }
    }
}