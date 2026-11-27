using UnityEngine;

public class NozzleTether : MonoBehaviour
{
    [Header("Налаштування обмеження дистанції (імітація шланга)")]
    public Transform anchorPoint;      // Точка кріплення на колонці (NozzleHolderSocket)
    public float maxDistance = 3.0f;   // Максимальна відстань у метрах

    private Rigidbody rb;
    private Behaviour grabInteractable;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent("XRGrabInteractable") as Behaviour;
    }

    void Update()
    {
        if (anchorPoint == null) return;

        float currentDistance = Vector3.Distance(transform.position, anchorPoint.position);

        if (currentDistance > maxDistance)
        {
            ReturnToHolder();
        }
    }

    public void ReturnToHolder()
    {
        // Примусово відпускаємо пістолет із VR-руки, щоб уникнути конфлікту фізики
        if (grabInteractable != null && grabInteractable.enabled)
        {
            grabInteractable.enabled = false;
            Invoke(nameof(ReEnableGrab), 0.25f);
        }

        // Обнуляємо фізичну швидкість
        if (rb != null)
        {
#if UNITY_6000_0_OR_NEWER
            rb.linearVelocity = Vector3.zero;
#else
            rb.velocity = Vector3.zero;
#endif
            rb.angularVelocity = Vector3.zero;
        }

        // Повертаємо пістолет на кріплення колонки
        transform.position = anchorPoint.position;
        transform.rotation = anchorPoint.rotation;

        Debug.Log("Досягнуто максимальної довжини шланга! Пістолет повернуто на колонку.");
    }

    private void ReEnableGrab()
    {
        if (grabInteractable != null)
            grabInteractable.enabled = true;
    }
}