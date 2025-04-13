using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float sensitivity = 2f;
    [SerializeField] private float maxLookX = 80f;

    private float rotationX = 0f;

    public void Look(Vector2 mouseInput)
    {
        rotationX -= mouseInput.y * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -maxLookX, maxLookX);

        cameraTransform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.Rotate(Vector3.up * mouseInput.x * sensitivity);
    }
}