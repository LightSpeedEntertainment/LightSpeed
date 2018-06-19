using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour {

	public Vector2 offset;
	public float speed;

	private Vector3 originalPosition;

	private void Start()
	{
		originalPosition = transform.position;
	}

	public void ButtonMove()
	{
		originalPosition = transform.position;
		Vector3 newPosition = transform.position - new Vector3(offset.x, offset.y, 0);

		transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * speed);
	}

	public void ButtonReturn()
	{
		transform.position = originalPosition;
	}
}