using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Vector2 PointerPosition { get; set; }
    public bool IsAttacking { get; set; }

    [Header("Swing Settings")]
    public float swingSpeed = 5f;
    public float swingAngle = 45f;

    private float swingTimer = 0f;

    void Update()
    {
        Vector2 aimDirection = (PointerPosition - (Vector2)transform.position).normalized;
        float baseAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        if (IsAttacking)
        {
            swingTimer += Time.deltaTime * swingSpeed;
            float offset = Mathf.Sin(swingTimer) * swingAngle;
            transform.rotation = Quaternion.Euler(0f, 0f, baseAngle + offset);
        }
        else
        {
            swingTimer = 0f;
            transform.right = aimDirection; // reset to aim without offset
        }
    }
}
