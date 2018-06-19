using UnityEngine;

public class DevTools : MonoBehaviour {

	public GameObject toolsObj;
	public GameObject player;
	public GameObject m_camera;

	[SerializeField]
	private bool t_Enabled;

	private Transform selected;
	private float x, y;

	private void Tools()
	{
		if (!t_Enabled)
		{
			player.GetComponent<PlayerController>().enabled = true;
			m_camera.SetActive(true);
			toolsObj.SetActive(false);
			return;
		}

		player.GetComponent<PlayerController>().enabled = false;
		m_camera.SetActive(false);
		toolsObj.SetActive(true);

		#region Movement

		if (Time.timeScale > 0f)
		{
			x += Input.GetAxis("Mouse X") * Time.deltaTime * (100f / Time.timeScale);
			y -= Input.GetAxis("Mouse Y") * Time.deltaTime * (100f / Time.timeScale);
		}

		y = Mathf.Clamp(y, -90f, 90f);

		toolsObj.transform.eulerAngles = new Vector3(y, x, 0f);

		float v = Input.GetAxisRaw("Vertical") * 0.5f;
		float h = Input.GetAxisRaw("Horizontal") * 0.5f;
		toolsObj.transform.Translate(transform.right * h + transform.forward * v);

		#endregion

		#region Control

		Ray camRay = new Ray(toolsObj.transform.position, toolsObj.transform.forward);
		RaycastHit camHit;

		if (Physics.Raycast (camRay, out camHit))
		{
			Transform hitObj = camHit.transform;

			if (Input.GetMouseButtonDown(0))
				if (hitObj.tag != "Ground")
					selected = hitObj;

			if (Input.GetMouseButton(1))
			{
				if (selected != null)
				{
					selected.eulerAngles = -camHit.normal;
					selected.position = camHit.point;
				}

				selected = null;
			}
		}

		#endregion
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.F12))
			t_Enabled = !t_Enabled;

		Tools();
	}
}