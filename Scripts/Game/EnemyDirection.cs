using UnityEngine;

public class EnemyDirection : MonoBehaviour {

	public Transform target;

	public void Update()
	{
		if (target != null)
		{
			transform.LookAt(target.position, Vector3.up);

			Vector3 rotation = transform.rotation.eulerAngles;
			rotation.x = 0f;
			rotation.z = 0f;

			transform.rotation = Quaternion.Euler(rotation);
		}
		else
			gameObject.SetActive(false);
	}
}