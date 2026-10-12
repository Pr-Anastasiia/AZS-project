using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Швидкість переміщення камери
    public float speed = 5f;

    void Update()
    {
        // Отримуємо дані з клавіатури (клавіші W, A, S, D або стрілочки)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Переміщуємо камеру
        transform.Translate(new Vector3(x, 0, z) * speed * Time.deltaTime);
    }
}