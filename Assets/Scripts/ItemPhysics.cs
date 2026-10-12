using UnityEngine;

public class ItemPhysics : MonoBehaviour
{
    // Ця функція спрацьовує автоматично, коли об'єкт вдаряється об щось фізичне
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Пістолет вдарився об: " + collision.gameObject.name);
    }
}