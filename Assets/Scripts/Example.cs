using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class Example : MonoBehaviour
{
    [SerializeField] InputActionReference moveAction;
    [SerializeField] InputActionReference jumpAction;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    Rigidbody rb;
    Vector3 movementDirection;
    public bool IsJumping;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        moveAction.action.Enable(); //Añade el listener
        jumpAction.action.Enable();
    }
    private void OnDisable()
    {
        moveAction.action.Disable();
        jumpAction.action.Disable();
    }

    void Update()
    {
        Vector2 direction = moveAction.action.ReadValue<Vector2>();
        movementDirection = new Vector3(direction.x, 0, direction.y);
        if (jumpAction.action.WasPressedThisFrame())
        {
            IsJumping = true;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movementDirection * speed;
        if (IsJumping == true)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            IsJumping = false;
        }
    }
}
