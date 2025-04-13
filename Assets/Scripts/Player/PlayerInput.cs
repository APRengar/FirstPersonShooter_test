using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 GetMoveInput() => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    public Vector2 GetMouseInput() => new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    public bool IsJumpPressed() => Input.GetButtonDown("Jump");
}