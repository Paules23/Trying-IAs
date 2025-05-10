using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public float attackDuration = 0.2f;
    public float rotationAngle = 30f;
    public Transform swordVisual; // Hijo visual

    private bool isAttacking = false;
    private Quaternion initialRotation;
    private Quaternion finalRotation;

    void Start()
    {
        if (swordVisual != null)
            swordVisual.gameObject.SetActive(false);

        initialRotation = transform.localRotation;
        finalRotation = Quaternion.Euler(0, 0, transform.localEulerAngles.z - rotationAngle);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    private System.Collections.IEnumerator Attack()
    {
        isAttacking = true;

        if (swordVisual != null)
            swordVisual.gameObject.SetActive(true);

        float elapsed = 0f;

        while (elapsed < attackDuration)
        {
            float t = elapsed / attackDuration;
            transform.localRotation = Quaternion.Lerp(initialRotation, finalRotation, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localRotation = initialRotation;

        if (swordVisual != null)
            swordVisual.gameObject.SetActive(false);

        isAttacking = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isAttacking && collision.CompareTag("Destructible"))
        {
            Destroy(collision.gameObject);
        }
    }
}
