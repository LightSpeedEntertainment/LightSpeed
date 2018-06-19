using UnityEngine;

public class TPCam : MonoBehaviour {

	public Transform followObj;
	public GameObject cameraObj;
	public GameObject playerObj;

	public float cameraMoveSpeed = 120f;
	
	public float xClamp = 75f;
	public float yClamp = 75f;
	public float sensitivity;
	public float sensitivitySlow;

	public Vector3 offset;

	private Vector3 followPosition;

	private float mouseX;
	private float mouseY;
	private float rotX = 0f;
	private float rotY = 0f;

	private void Start()
	{
		Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	private void Update()
	{
		mouseX = Input.GetAxis("Mouse X");
		mouseY = -Input.GetAxis ("Mouse Y");

		if (Time.timeScale < 1f)
		{
			rotY += mouseX * sensitivitySlow * Time.deltaTime;
			rotX += mouseY * sensitivitySlow * Time.deltaTime;
		}
		else
		{
			rotY += mouseX * sensitivity * Time.deltaTime;
			rotX += mouseY * sensitivity * Time.deltaTime;
		}


			rotX = Mathf.Clamp(rotX, -xClamp, yClamp);

		Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0f);
		transform.rotation = localRotation;
	}

	private void LateUpdate()
	{
		UpdateCamera();
	}

	private void UpdateCamera()
	{
		Transform target = followObj;

		float step = cameraMoveSpeed * Time.unscaledDeltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}
}