using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball2DController : MonoBehaviour
{
    public float maxSpeed = 1f;

    private Rigidbody2D rb;

    [SerializeField] private InputActionReference movement, pointerPosition, attack;


    [SerializeField] private WeaponParent weaponParent;


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
        if (attack.action != null && attack.action.WasPressedThisFrame())
        {
            Debug.Log("Attack input detected");

            if (attack.action != null && attack.action.WasPressedThisFrame())
            {
                StartCoroutine(weaponParent.Swing(-150f, 0.2f));
            }

        }

    }

    private IEnumerator UnlockWeaponAim(float delay)
    {
        yield return new WaitForSeconds(delay);
        weaponParent.aimEnabled = true;
    }


    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
    private void RotateWeaponBy(float zDegrees)
    {
        Vector3 currentEuler = weaponParent.transform.eulerAngles;
        currentEuler.z += zDegrees;
        weaponParent.transform.eulerAngles = currentEuler;
    }
}
