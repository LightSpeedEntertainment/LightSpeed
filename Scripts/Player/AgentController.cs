using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentController : MonoBehaviour {

	public NavMeshAgent m_Agent;

	public float moveSpeed = 5f;

	private Vector3 target;

	private void Update()
	{
		m_Agent.speed = moveSpeed;

		if (Input.GetAxisRaw("Horizontal") == 0f && Input.GetAxisRaw("Vertical") == 0f)
			target = transform.position;
		else
			target = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) + transform.position;

		m_Agent.SetDestination(target);
	}
}