using UnityEngine;

public class PlayerCamera : MonoBehaviour {

	public Transform m_Target;

	public float smoothing = 0.1f;
	public float sensitivity = 15f;
	public float minFov;
	public float maxFov;

	private Vector3 offset;

	private void Start ()
	{
		offset = transform.position - m_Target.position;
	}

	private void Update()
	{
		float newFov = Camera.main.fieldOfView;

		newFov += -Input.GetAxis("Mouse ScrollWheel") * sensitivity;
		newFov = Mathf.Clamp(newFov, minFov, maxFov);

		Camera.main.fieldOfView = newFov;
	}

	private void FixedUpdate()
	{
		if (m_Target == null)
			return;

		Vector3 newPos = m_Target.position + offset;
		transform.position = Vector3.Lerp(
			transform.position,
			newPos,
			smoothing * Time.unscaledDeltaTime);
	}
}