using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseBTN : MonoBehaviour
{
	public GameObject pauseMenuPanel; // Reference to the Pause Menu UI Panel
	private bool isPaused = false;

	// Function to Show the Pause Menu and Stop the Game
	public void ShowMenuPanel()
	{
		pauseMenuPanel.SetActive(true);
		Time.timeScale = 0f; // Stop the game
		isPaused = true;
	}

	// Function to Resume the Game
	public void ResumeGame()
	{
		pauseMenuPanel.SetActive(false);
		Time.timeScale = 1f; // Resume the game
		isPaused = false;
	}

	// Function to Navigate to Main Menu
	public void BackToMainMenu()
	{
		Time.timeScale = 1f; // Reset time scale
		SceneManager.LoadScene("MainMenu"); // Load the Main Menu Scene
	}

	// Function to Quit the Game
	public void QuitGame()
	{
		Debug.Log("Quit Game!");
		Application.Quit();

		// For editor testing
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
	}
}
