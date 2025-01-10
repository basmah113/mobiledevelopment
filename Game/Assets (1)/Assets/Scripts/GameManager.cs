using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
	public GameObject gameOverPanel;
	public GameObject levelCompletedPanel;
	public Text tapToStartText;
	[SerializeField] private Transform spawnPoint;
	[SerializeField] private GameObject[] ballPrefabs;

	public GameObject activePlayer;
	private bool gameStarted = false;

	private int currentLevelCoins = 0;

	private void Start()
	{
		Time.timeScale = 0;
		gameOverPanel.SetActive(false);
		levelCompletedPanel.SetActive(false);

		SpawnSelectedBall();
	}

	private void Update()
	{
		if (!gameStarted && Input.GetMouseButtonDown(0) /*&& Input.touchCount > 0*/)
		{
			Time.timeScale = 1;
			gameStarted = true;

			if (tapToStartText != null)
			{
				tapToStartText.gameObject.SetActive(false);
			}

			Accelerometer accel = activePlayer.GetComponent<Accelerometer>();
			if (accel != null)
			{
				accel.StartGame();
			}
		}
	}

	private void SpawnSelectedBall()
	{
		int selectedBallIndex = PlayerPrefs.GetInt("SelectedBall", 0);

		if (activePlayer != null)
		{
			Destroy(activePlayer);
		}

		activePlayer = Instantiate(ballPrefabs[selectedBallIndex], spawnPoint.position, Quaternion.identity);
		activePlayer.name = "Player";

		
		SwipeJump swipeJump = activePlayer.GetComponent<SwipeJump>();
		if (swipeJump != null)
		{
			Transform groundCheck = activePlayer.transform.Find("GroundCheck");
			if (groundCheck != null)
			{
				swipeJump.groundCheck = groundCheck;

				Debug.Log($"GroundCheck assigned to {swipeJump.groundCheck.name}");
			}
			else
			{
				Debug.LogError("GroundCheck not found in prefab: " + ballPrefabs[selectedBallIndex].name);
			}
		}

		GyroControl gyroControl = FindObjectOfType<GyroControl>();
		if (gyroControl != null)
		{
			gyroControl.player = activePlayer.transform; 
		}
	}

	public void AddCoin()
	{
		currentLevelCoins++;
		Debug.Log("Coins Collected: " + currentLevelCoins);
	}

	public void GameOver()
	{
		Debug.Log("Game Over Triggered!");
		CollectableControl.SaveCoins();
		Time.timeScale = 0;
		gameOverPanel.SetActive(true);
	}

	public void LevelCompleted()
	{
		Debug.Log("Level Completed UI Triggered!");
		Time.timeScale = 0;
		levelCompletedPanel.SetActive(true);

		CollectableControl.SaveCoins();

		int currentLevel = SceneManager.GetActiveScene().buildIndex;
		int nextLevel = currentLevel + 1;

		if (PlayerPrefs.GetInt("UnlockedLevel", 1) < nextLevel)
		{
			PlayerPrefs.SetInt("UnlockedLevel", nextLevel);
		}
		PlayerPrefs.SetInt("SavedLevel", nextLevel);
		PlayerPrefs.Save();

		Debug.Log($"Progress Saved! Current Level: {currentLevel}, Unlocked Level: {nextLevel}");
	}

	public void ReplayGame()
	{
		Debug.Log("Replay button clicked");

		CollectableControl.coinCount = 0;

		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void NextLevel()
	{
		Time.timeScale = 1;
		int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

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

	public void MainMenu()
	{
		Debug.Log("Main Menu button clicked!");
		Time.timeScale = 1;
		SceneManager.LoadScene("MainMenu");
	}

	public void QuitGame()
	{
		Debug.Log("Quit Game button clicked!");
		Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
	}
}
