using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement movement;
    private PlayerJump jump;
    private PlayerAim look;
    private PlayerInput input;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        jump = GetComponent<PlayerJump>();
        look = GetComponent<PlayerAim>();
        input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        movement.SetMoveInput(input.GetMoveInput());
        movement.Move();

        jump.ApplyJump(input.IsJumpPressed());

        look.Look(input.GetMouseInput());
    }
}