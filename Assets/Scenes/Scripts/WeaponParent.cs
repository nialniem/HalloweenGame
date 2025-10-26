using System.Collections;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Vector2 PointerPosition { get; set; }
    public bool IsAttacking { get; set; }
    public bool LockRotation { get; internal set; }
    public bool aimEnabled = true;
    [Header("Swing Settings")]
    public float swingSpeed = 5f;
    public float swingAngle = 45f;

    private float swingTimer = 0f;

    void Update()
    {
        Vector2 aimDirection = (PointerPosition - (Vector2)transform.parent.position).normalized;
        float baseAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        if (aimEnabled)
        {
            transform.right = aimDirection;
        }

        if (IsAttacking)
        {
            swingTimer += Time.deltaTime * swingSpeed;
            float offset = Mathf.Sin(swingTimer) * swingAngle;
            transform.rotation = Quaternion.Euler(0f, 0f, baseAngle + offset);
        }
        else
        {
            swingTimer = 0f;
            transform.right = aimDirection;
        }

       
        float swordRadius = 0.5f;
        transform.position = (Vector2)transform.parent.position + aimDirection * swordRadius;
    }

    public IEnumerator Swing(float angle, float duration)
    {
        aimEnabled = false;

        float elapsed = 0f;
        float startZ = transform.eulerAngles.z;
        float targetZ = startZ + angle;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            float z = Mathf.Lerp(startZ, targetZ, t);
            transform.rotation = Quaternion.Euler(0f, 0f, z);
            yield return null;
        }

        aimEnabled = true;
    }

}
