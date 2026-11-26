using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
public class MovementFPS : MonoBehaviour
{
    [SerializeField] private InputActionReference move, look, jump, run;
    [SerializeField] private Camera camera;
    [SerializeField] private List<LayerMask> groundLayer;
    [SerializeField] private float walkSpeed, runSpeed, jumpForce, mouseSensitivity;

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
        Cursor.lockState = CursorLockMode.Locked;
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

    // Update is called once per frame
    void Update()
    {
        mouseInput = move.action.ReadValue<Vector2>();
        isRunning = run.action.IsPressed();
        if ((jump.action.WasPressedThisFrame())
        {
            isJumping = true
        }
    }
}
