using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball2DController : MonoBehaviour
{
    public float maxSpeed = 1f;

    private Rigidbody2D rb;

    [SerializeField] private InputActionReference movement, pointerPosition, attack;


    private WeaponParent weaponParent;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;

        weaponParent = GetComponentInChildren<WeaponParent>();
        
        movement.action.Enable();
        pointerPosition.action.Enable();
    }

    void FixedUpdate()
    {
        Vector2 moveInput = movement.action.ReadValue<Vector2>();
        Vector2 moveDirection = moveInput.normalized;

        rb.AddForce(moveDirection * maxSpeed);

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    void Update()
    {
        Vector2 pointerInput = GetPointerInput();
        weaponParent.PointerPosition = pointerInput;

        if (weaponParent != null)
        {
            weaponParent.PointerPosition = pointerInput;
        }
    }

    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
