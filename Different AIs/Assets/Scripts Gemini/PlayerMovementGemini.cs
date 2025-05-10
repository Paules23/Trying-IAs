using UnityEngine;

public class PlayerMovementGemini : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool canJump;
    private float horizontalInput; // Añadimos esta variable

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canJump = true;
        isGrounded = false;
    }

    private void Update()
    {
        // Movimiento horizontal
        horizontalInput = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1f;
        }

        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        rb.velocity = movement;

        // Salto
        if (Input.GetKeyDown(KeyCode.W) && canJump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            canJump = false;
            isGrounded = false;
        }

        // Permitir saltar de nuevo solo si está en el suelo
        if (isGrounded && !canJump)
        {
            canJump = true;
        }
    }

    // Nueva función para obtener la entrada horizontal
    public float GetHorizontalInput()
    {
        return horizontalInput;
    }
}