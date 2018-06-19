using UnityEngine;

public class Menu : MonoBehaviour {

	[SerializeField]
	private GameObject pauseMenu;

	public PlayerController m_PlayerController;
	public Speed m_Speed;

	public bool paused = false;

	private bool speedWasEnabled;

	private float previousTimeScale;

	private void Start()
	{
		if (!paused)
			pauseMenu.SetActive(false);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			paused = !paused;

			if (m_Speed.enabled == true)
				speedWasEnabled = true;

			UpdatePause(paused);
		}
	}

	public void UpdatePause(bool isPaused)
	{
		paused = isPaused;

		if (isPaused)
		{
			previousTimeScale = Time.timeScale;

			Cursor.lockState = CursorLockMode.None;

			m_PlayerController.enabled = false;
			if (speedWasEnabled)
				m_Speed.enabled = false;

			Time.timeScale = 0f;
			pauseMenu.SetActive(true);
		}
		else
		{
			Time.timeScale = previousTimeScale;
			pauseMenu.SetActive(false);

			Cursor.lockState = CursorLockMode.Locked;

			m_PlayerController.enabled = true;
			if (speedWasEnabled)
				m_Speed.enabled = true;
		}
	}

	public void Exit()
	{
		Application.Quit();
	}
}