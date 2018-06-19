using UnityEngine;
using UnityEngine.AI;

public class SpeedEnemy : MonoBehaviour {

	public float wanderRadius;
	public float wanderTimer;

	public Transform target;
	private NavMeshAgent agent;
	private float timer;

	private void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		timer = wanderTimer;
	}

	public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layerMask)
	{
		Vector3 randDir = Random.insideUnitSphere * dist;
		randDir += origin;

		NavMeshHit navHit;
		NavMesh.SamplePosition(randDir, out navHit, dist, layerMask);

		return navHit.position;
	}

	private void Update()
	{
		timer += Time.deltaTime;

		if (timer >= wanderTimer)
		{
			Vector3 newPos = RandomNavSphere(target.position, wanderRadius, -1);
			agent.SetDestination(newPos);
			transform.LookAt(newPos);

			Vector3 angles = transform.eulerAngles;
			angles.x = 0;
			angles.z = 0;

			transform.eulerAngles = angles;

			timer = 0f;
		}
	}
}