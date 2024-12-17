using UnityEngine;

public class SwipeJump : MonoBehaviour
{
	private Vector2 startTouchPosition;
	private Vector2 endTouchPosition;
	private Rigidbody rigid;

	public float jumpForce = 3f; // Adjust the jump force
	public Transform groundCheck; // Assign the GroundCheck Transform in the Inspector
	public LayerMask groundLayer; // Assign "Ground" Layer in the Ins
	public float groundCheckRadius = 0.2f; // Radius for the ground check

	private bool isGrounded;

	private void Start()
	{
		rigid = GetComponent<Rigidbody>(); // Reference to the Rigidbody
	}
	private void Update()
	{
		// Ground check using OverlapSphere
		isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

		if (isGrounded && Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Began)
			{
				Jump();
			}
		}
	}

	private void Jump()
	{
		// Apply an upward force to make the sphere jump
		if (isGrounded) // Ensure the sphere is on the ground
		{
			rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		}
	}

	private void OnDrawGizmos()
	{
		// Visualize the ground check in the editor
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
	}
}
