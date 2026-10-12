using UnityEngine;

public class FuelZone : MonoBehaviour
{
    // Ця функція спрацьовує, коли інший об'єкт заходить у цю зону
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("У зону заправки потрапив об'єкт: " + other.gameObject.name);
    }
}