using System.Collections;
using UnityEngine;

public class GyroControl : MonoBehaviour
{
	private bool gyroEnabled;
	private Gyroscope gyro;

	private GameObject cameraContainer;
	private Quaternion initialRotation;
	private Quaternion rot;

	public Transform player; // Reference to the player object


	private void Start()
	{
		// Create the camera container and align it to the initial camera position and rotation
		cameraContainer = new GameObject("Camera Container");
		cameraContainer.transform.position = player.position; // Anchor to the player position
		cameraContainer.transform.rotation = Quaternion.identity;
		transform.SetParent(cameraContainer.transform);


		// Enable gyro and calibrate
		gyroEnabled = EnableGyro();

		if (gyroEnabled)
		{
			StartCoroutine(CalibrateGyro());
		}

		transform.localRotation = Quaternion.identity;

	}

	private bool EnableGyro()
	{
		if (SystemInfo.supportsGyroscope)
		{
			gyro = Input.gyro;
			gyro.enabled = true;

			// Adjust rotation for landscape mode (Z-axis pointing forward)
			rot = Quaternion.Euler(90f, 0f, 0f);
			return true;
		}
		return false;
	}

	private IEnumerator CalibrateGyro()
	{
		yield return new WaitForSeconds(0.5f); // Wait for gyroscope data to stabilize

		// Adjust initial rotation to align with the road and device orientation
		initialRotation = Quaternion.Inverse(gyro.attitude);

		// Align the camera container to match the initial rotation
		cameraContainer.transform.rotation = Quaternion.identity;
	}

	private void Update()
	{
		if (gyroEnabled)
		{
			Quaternion gyroRotation = initialRotation * gyro.attitude * rot;
			transform.localRotation = gyroRotation;

			cameraContainer.transform.position = player != null ? player.position : Vector3.zero;

		}
	}
}
