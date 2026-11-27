using UnityEngine;
using UnityEngine.InputSystem;
public class MovementFPS : MonoBehaviour
{
    [SerializeField] private InputActionReference move, look, jump, run;
    [SerializeField] private Camera camera;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float walkSpeed, runSpeed, jumpForce, mouseSensitivity, cameraIncline;

    [SerializeField] private Transform cameraOrientation;
    private Rigidbody rb;
    private bool isRunning, isJumping;
    private Vector2 mouseInput;

    private void Awake()
    {
       rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        move.action.Enable();
        look.action.Enable();
        jump.action.Enable();
        run.action.Enable();
        Cursor.lockState = CursorLockMode.Locked;//bloquea el cursor en el centro
    }
    private void OnDisable()
    {
        move.action.Disable();
        look.action.Disable();
        jump.action.Disable();
        run.action.Disable();
    }
    void Start()
    {

    }

    void Update()
    {
        mouseInput = move.action.ReadValue<Vector2>();
        isRunning = run.action.IsPressed();
        if (jump.action.WasPressedThisFrame())
        {
            isJumping = true;
        }
        mouseInput = look.action.ReadValue<Vector2>();
        cameraOrientation.Rotate(0f, mouseInput.x * mouseSensitivity, 0f);//movimiento camara horizontal
        cameraIncline -= mouseInput.y * mouseSensitivity;
        cameraIncline = Mathf.Clamp(cameraIncline, -80f, 80f);
        cameraOrientation.localRotation = Quaternion.Euler(cameraIncline, 0f, 0f);
    }
}
