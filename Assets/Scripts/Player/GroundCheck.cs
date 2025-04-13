using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private float checkDistance = 0.3f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundCheckPoint;

    public bool IsGrounded { get; private set; }

    void Update()
    {
        IsGrounded = Physics.CheckSphere(groundCheckPoint.position, checkDistance, groundMask);
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheckPoint == null) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheckPoint.position, checkDistance);
    }
}