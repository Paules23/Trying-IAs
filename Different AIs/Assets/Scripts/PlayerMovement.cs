using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private bool isGrounded = true; // Controla si el jugador está en el suelo
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Asignamos el Rigidbody2D
    }

    private void Update()
    {
        float moveX = 0f;

        // Movimiento lateral con A y D
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
        }

        // Aplicar movimiento horizontal
        transform.position += new Vector3(moveX * speed * Time.deltaTime, 0f, 0f);
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        // Salto con impulso cuando presionas W una vez
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false; // Evita que el jugador vuelva a saltar en el aire
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Detecta si ha tocado el suelo para permitir un nuevo salto
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
