using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class Example : MonoBehaviour
{
    [SerializeField] InputActionReference moveAction;
    [SerializeField] InputActionReference jumpAction;
    [SerializeField] float velocity;
    [SerializeField] float jumpForce;
    Rigidbody rb;
    Vector3 movementDirection;


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

    }

    private void FixedUpdate()
    {
        if (jumpAction.action.WasPressedThisFrame())
        {
            movementDirection.y = jumpForce;
        }
        rb.AddForce(movementDirection * velocity, ForceMode.Force);
        movementDirection.y = 0;
    }
}
