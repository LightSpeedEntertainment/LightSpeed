using UnityEngine;
using UnityEngine.UI;

public class SubMenu : MonoBehaviour {

	public GameObject panel;

	public bool playAnimation;
	public float smoothTime;

	public bool active;

	private float velocity;

	public bool open = false;

	private bool opening;

	public void Activate()
	{
		if (playAnimation)
		{
			opening = true;
			panel.SetActive(true);
		}
		else
		{
			opening = false;
			panel.SetActive(true);
		}
	}

	public void Disable()
	{
		if (!playAnimation)
			panel.SetActive(false);
		else
		{
			RectTransform m_Transform = panel.GetComponent<RectTransform>();
			m_Transform.localScale = new Vector3(1f, 0f, 1f);

			panel.SetActive(false);
		}
	}

	private void Update()
	{
		if (active)
		{
			Activate();
		}
		else
			Disable();

		if (playAnimation)
		{
			if (opening)
			{
				RectTransform m_Transform = panel.GetComponent<RectTransform>();
				m_Transform.localScale = Vector3.Lerp(m_Transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * smoothTime);

				if (panel.GetComponent<RectTransform>().localScale == new Vector3(1f, 1f, 1f))
					opening = false;
			}
		}
	}
}