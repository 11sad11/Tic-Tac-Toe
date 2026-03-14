using UnityEngine;
using UnityEngine.InputSystem;

public class Eyes : MonoBehaviour
{
    [Range(0, 60)] public float t;

    void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector2 direction = mousePos - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 180;
        angle = Mathf.LerpAngle(transform.eulerAngles.z, angle, t * Time.deltaTime);
        transform.eulerAngles = new(0, 0, angle);
    }
}