using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerCrouch : MonoBehaviour
{
    [Header("Height Settings")]
    [SerializeField] private float standHeight = 2.0f;
    [SerializeField] private float crouchHeight = 1.0f;

    [Header("Speed Settings")]
    [SerializeField] private float standSpeed = 4f;
    [SerializeField] private float crouchSpeed = 2f;

    [Header("Transition")]
    [SerializeField] private float crouchTransitionSpeed = 10f;

    [Header("Key")]
    [SerializeField] private KeyCode crouchKey = KeyCode.LeftControl;

    private CharacterController controller;
    private float targetHeight;
    private Vector3 targetCenter;

    private float originalCenterY;
    public bool IsCrouching { get; private set; }

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        originalCenterY = controller.center.y;
        targetHeight = standHeight;
        targetCenter = new Vector3(0, originalCenterY, 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(crouchKey))
        {
            Crouch();
        }
        else if (Input.GetKeyUp(crouchKey))
        {
            TryStandUp();
        }

        // Плавный переход
        controller.height = Mathf.Lerp(controller.height, targetHeight, Time.deltaTime * crouchTransitionSpeed);
        controller.center = Vector3.Lerp(controller.center, targetCenter, Time.deltaTime * crouchTransitionSpeed);
    }

    private void Crouch()
    {
        IsCrouching = true;
        targetHeight = crouchHeight;
        targetCenter = new Vector3(0, crouchHeight / 2f, 0);
    }

    private void TryStandUp()
    {
        // // Проверка, можно ли встать (Ray вверх)
        // if (!Physics.Raycast(transform.position, Vector3.up, standHeight - crouchHeight + 0.1f))
        // {
            IsCrouching = false;
            targetHeight = standHeight;
            targetCenter = new Vector3(0, originalCenterY, 0);
        // }
        // else
        // {
        //     Debug.Log("Невозможно встать: над головой препятствие.");
        // }
    }

    public float GetCurrentSpeedMultiplier()
    {
        return IsCrouching ? crouchSpeed : standSpeed;
    }
}