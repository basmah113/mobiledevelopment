using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
	public GameObject gameOverPanel; // Reference to the Game Over UI Panel
	public GameObject levelCompletedPanel;
	public Text tapToStartText;      // Reference to the "Tap to Start" UI Text
	public GameObject player;        // Reference to the player GameObject
	private bool gameStarted = false;

	private void Start()
	{
		Time.timeScale = 0; // Pause the game at the start
		gameOverPanel.SetActive(false); // Ensure Game Over panel is hidden initially
		levelCompletedPanel.SetActive(false);
	}

	private void Update()
	{
		if (!gameStarted && Input.touchCount > 0)
		{
			Time.timeScale = 1; // Resume the game
			gameStarted = true;

			if (tapToStartText != null)
			{
				tapToStartText.gameObject.SetActive(false);
			}

			// Start player movement
			Accelerometer accel = player.GetComponent<Accelerometer>();
			if (accel != null)
			{
				accel.StartGame();
			}
		}
	}

	public void GameOver()
	{
		Debug.Log("Game Over Triggered!");
		Time.timeScale = 0; // Stop the game
		gameOverPanel.SetActive(true); // Show the Game Over panel
	}

	public void LevelCompleted()
	{
		Debug.Log("Level Completed UI Triggered!");
		Time.timeScale = 0; // Stop the game
		levelCompletedPanel.SetActive(true); // Show Level Completed UI
	}

	public void ReplayGame()
	{
		Debug.Log("Replay button clicked");
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void NextLevel()
	{
		Time.timeScale = 1; // Reset time scale
		int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

		// Check if the next scene exists
		if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
		{
			Debug.Log("Loading Scene Index: " + nextSceneIndex);
			SceneManager.LoadScene(nextSceneIndex);
		}
		else
		{
			Debug.Log("No more levels to load!");
		}
	}


	public void QuitGame()
	{
		Debug.Log("Quit Game button clicked!");

		// Quit in build
		Application.Quit();

		// Quit in Unity Editor
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#endif
	}
}
