using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Laser : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
	{
		// Check if the player has collided with the laser
		if (other.CompareTag("Player"))
		{
			Debug.Log("Player hit the laser!");
			// Example behavior: Stop the player, reset position, or display a message
			RespawnPlayer(other.gameObject);
		}
	}

	void RespawnPlayer(GameObject player)
	{
		// Reset player's position to a predefined respawn point
		player.transform.position = new Vector3(0, 1, 0); // Set this to your respawn coordinates
		Debug.Log("Player respawned!");
	}
}

