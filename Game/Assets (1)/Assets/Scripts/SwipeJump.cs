using UnityEngine;

public class SwipeJump : MonoBehaviour
{
	private Rigidbody rigid;

	public float jumpForce = 5f; // Adjust the jump force
	public Transform groundCheck; // Assign the GroundCheck Transform in the Inspector
	public LayerMask groundLayer; // Assign "Ground" Layer in the Inspector
	public float groundCheckRadius = 0.5f; // Radius for the ground check

	private bool isGrounded;
	private Vector2 startTouchPosition;
	private Vector2 endTouchPosition;
	private float swipeThreshold = 50f; // Minimum swipe distance to trigger a jump

	private void Start()
	{
		rigid = GetComponent<Rigidbody>(); // Reference to the Rigidbody
	}

	private void Update()
	{
		// Detect touch input
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Began)
			{
				// Record the initial touch position
				startTouchPosition = touch.position;
			}
			else if (touch.phase == TouchPhase.Ended)
			{
				// Record the end touch position
				endTouchPosition = touch.position;

				// Check for a vertical swipe
				DetectSwipe();
			}
		}
	}

	private void DetectSwipe()
	{
		Vector2 swipeDelta = endTouchPosition - startTouchPosition;

		// Check if the swipe is primarily vertical
		if (Mathf.Abs(swipeDelta.y) > Mathf.Abs(swipeDelta.x))
		{
			if (swipeDelta.y > 50) // Swipe up
			{
				Jump();
			}
		}
	}

	private void Jump()
	{
		// Apply an upward force to make the sphere jump
		if (Mathf.Abs(rigid.velocity.y) < 0.01f) // Ensure the sphere is on the ground
		{
			rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		}
	}
}
