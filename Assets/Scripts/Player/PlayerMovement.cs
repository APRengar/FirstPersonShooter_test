using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float baseSpeed = 5f;
    private PlayerCrouch crouchController;

    private CharacterController controller;
    private Vector3 moveInput;

    public Vector3 MoveInput => moveInput;

    public void SetMoveInput(Vector2 input)
    {
        moveInput = transform.right * input.x + transform.forward * input.y;
    }

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        controller = GetComponent<CharacterController>();
        crouchController = GetComponent<PlayerCrouch>();
    }

    public void Move()
    {
        controller.Move(moveInput * moveSpeed * Time.deltaTime);
    }
    
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        float currentSpeed = baseSpeed;

        if (crouchController != null)
            currentSpeed = crouchController.GetCurrentSpeedMultiplier();

        controller.Move(move * currentSpeed * Time.deltaTime);
    }
}