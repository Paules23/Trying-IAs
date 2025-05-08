using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    public void DestroyObject()
    {
        Debug.Log(gameObject.name + " ha sido destruido.");
        Destroy(gameObject); // El objeto se elimina
    }
}
