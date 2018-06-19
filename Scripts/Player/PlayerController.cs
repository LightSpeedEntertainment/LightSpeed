using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	#region Variables

	[HideInInspector]
	public Rigidbody m_Rigidbody;

	public Animator m_Animator;
	public Camera m_Camera;

	public GameObject[] lightningTrails;
	
	public Speed m_Speed;

	public float fovOnRun = 110f;

	public enum State { IDLE, RUNNING };
	public State state;

	public bool controlledByTime = true;

	//private float originalFov;

	private float dampVel;

	#endregion Variables

	private void Start()
	{
		m_Rigidbody = GetComponent<Rigidbody>();

		//originalFov = m_Camera.fieldOfView;
	}

	private void StateHandler()
	{
		if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
			state = State.RUNNING;
		else
			state = State.IDLE;

		if (state == State.RUNNING)
			m_Animator.SetBool("Running", true);
		else if (state == State.IDLE)
			m_Animator.SetBool("Running", false);
	}

	private void TransformHandler()
	{
		Vector3 normalRot = Vector3.zero;

		#region Position

		RaycastHit hit;
		if (Physics.Raycast(new Ray(transform.position, -transform.up), out hit))
		{
			Vector3 newY = transform.position;

			newY.x = transform.position.x;
			newY.y = hit.point.y + transform.GetComponent<Collider>().bounds.size.y / 2f;
			newY.z = transform.position.z;

			normalRot = -hit.normal;

			transform.position = newY;
		}

		#endregion

		#region Rotation

		Vector3 rotTar = transform.position + (
			(m_Camera.transform.forward * Input.GetAxisRaw("Vertical")) +
			(m_Camera.transform.right * Input.GetAxisRaw("Horizontal"))
			);

		transform.LookAt (rotTar);

		Vector3 angles = transform.eulerAngles;
		angles.x = 0f;
		angles.z = 0f;
		transform.eulerAngles = angles;

		#endregion
	}

	private void MovementHandler()
	{
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		Vector3 dir = m_Camera.transform.right * h + m_Camera.transform.forward * v;
		dir.y = 0f;

		m_Rigidbody.velocity = dir * m_Speed.moveSpeed;
	}

	private void LightningHandler()
	{
		foreach (GameObject lT in lightningTrails)
		{
			if (m_Speed.slowTime)
				lT.SetActive(true);
			else
				lT.SetActive(false);
		}
	}

	private void Update()
	{
		StateHandler();
		TransformHandler();
		LightningHandler();
	}

	private void FixedUpdate()
	{
		MovementHandler();
	}
}