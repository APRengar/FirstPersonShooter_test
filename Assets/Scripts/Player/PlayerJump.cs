using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerJump : MonoBehaviour
{
    [Header("Gravity Settings")]
    [SerializeField] private float gravity = -20f;
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float jumpHeight = 1.5f;

    private CharacterController controller;
    private GroundCheck groundChecker;
    private Vector3 velocity;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        groundChecker = GetComponent<GroundCheck>();
    }

    public void ApplyJump(bool jumpPressed)
    {
        // Приземление
        if (groundChecker.IsGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Прыжок
        if (jumpPressed && groundChecker.IsGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Падение усиливаем
        if (velocity.y < 0)
            velocity.y += gravity * fallMultiplier * Time.deltaTime;
        else
            velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}