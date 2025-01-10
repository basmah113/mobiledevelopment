using UnityEngine;

public class Accelerometer : MonoBehaviour
{
	public bool isFlat = true;
	public float sensitivity = 5f; // Sensitivity for tilt movement
	public float maxSpeed = 10f;   // Max speed limit for tilt movement
	private Rigidbody rigid;

	private bool gameStarted = false; // Flag to start the game

	private void Start()
	{
		rigid = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		// Stop movement until the game has started
		if (!gameStarted || Time.timeScale == 0)
		{
			rigid.velocity = Vector3.zero; // Reset velocity
			return;
		}

		// Get accelerometer input
		Vector3 tilt = Input.acceleration;

		// Adjust tilt for flat orientation
		if (isFlat)
		{
			tilt = Quaternion.Euler(90, 0, 0) * tilt;
		}

		// Clamp tilt to avoid extreme forces
		tilt = Vector3.ClampMagnitude(tilt, 1f);

		// Apply only horizontal forces: X and Z axis (ignore Y to prevent flying)
		Vector3 moveForce = new Vector3(tilt.x, 0, tilt.y) * sensitivity;

		// Apply forces only on X and Z axis, not Y (gravity is handled separately)
		rigid.AddForce(moveForce, ForceMode.Acceleration);

		// Clamp overall velocity
		Vector3 clampedVelocity = Vector3.ClampMagnitude(new Vector3(rigid.velocity.x, 0, rigid.velocity.z), maxSpeed);
		rigid.velocity = clampedVelocity + Vector3.up * rigid.velocity.y; // Preserve gravity on Y-axis

		Debug.DrawRay(transform.position, moveForce, Color.cyan);
		Debug.Log("Tilt: " + tilt + " | Velocity: " + rigid.velocity);
	}

	// Method to start movement, called by GameManager
	public void StartGame()
	{
		gameStarted = true;
	}
}
