using UnityEngine;

public class Speed : MonoBehaviour {

	public PlayerController m_PlayerController;

	public float timeFactor;

	public float sprintFactor = 20f;
	public float sprintFactorSlow = 5f;

	public float speedSlow;
	public float speed1;
	public float speed2;
	public float speed3;

	private float speedFast;

	[HideInInspector]
	public float moveSpeed;
	[HideInInspector]
	public bool slowTime;

	private float originalDelta;

	private void Start()
	{
		slowTime = false;
		speedFast = speed1;

		originalDelta = Time.fixedDeltaTime;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
			slowTime = !slowTime;

		UpdateTime();
		
		if (moveSpeed == speedSlow)
			m_PlayerController.m_Animator.speed = 1f;
		if (moveSpeed == speed1)
			m_PlayerController.m_Animator.speed = 20f;
		if (moveSpeed == speed2)
			m_PlayerController.m_Animator.speed = 27.5f;
		if (moveSpeed == speed3)
			m_PlayerController.m_Animator.speed = 35f;
	}

	public void UpdateTime()
	{
		if (slowTime)
		{
			Time.timeScale = timeFactor;
			Time.fixedDeltaTime = originalDelta * Time.timeScale;

			if (Input.GetKeyDown(KeyCode.Alpha1))
				speedFast = speed1;
			if (Input.GetKeyDown(KeyCode.Alpha2))
				speedFast = speed2;
			if (Input.GetKeyDown(KeyCode.Alpha3))
				speedFast = speed3;

			moveSpeed = speedFast;
		}
		else
		{
			Time.timeScale = 1f;
			Time.fixedDeltaTime = originalDelta;

			moveSpeed = speedSlow;
		}
	}
}