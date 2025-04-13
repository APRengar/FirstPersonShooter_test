using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

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
    }

    public void Move()
    {
        controller.Move(moveInput * moveSpeed * Time.deltaTime);
    }
}