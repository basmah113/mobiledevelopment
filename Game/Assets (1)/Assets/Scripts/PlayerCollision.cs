using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
	private GameManager gameManager;

	private void Start()
	{
		// Find the GameManager in the scene
		gameManager = FindObjectOfType<GameManager>();
	}

	private void OnTriggerEnter(Collider other)
	{
		// Check if the collided object has the "Laser" tag
		if (other.gameObject.CompareTag("Laser"))
		{
			Debug.Log("Player hit the Laser - Game Over!");

			// Trigger Game Over logic
			if (gameManager != null)
			{
				gameManager.GameOver();
			}

			// Stop the player's movement
			HandleLaserCollision();
		}

		// Check if the collided object has the "LastCoin" tag
		if (other.gameObject.CompareTag("LastCoin"))
		{
			Debug.Log("Player hit the LastCoin - Level Completed!");

			// Trigger Level Completed logic
			if (gameManager != null)
			{
				gameManager.LevelCompleted();
			}

			// Stop the player's movement
			HandleLaserCollision();
		}
	}

	private void HandleLaserCollision()
	{
		// Stop the player's Rigidbody movement
		Rigidbody rb = GetComponent<Rigidbody>();
		if (rb != null)
		{
			rb.velocity = Vector3.zero;        // Stop all movement
			rb.angularVelocity = Vector3.zero; // Stop all rotation
		}
	}
}
