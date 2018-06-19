using UnityEngine;
public class OptimizedRenderer : MonoBehaviour {

	private Transform Player;

	public GameObject[] sceneObjects;
	public float renderDistance = 15f;
	public float checkRate;

	private float nextCheck = 0;

	private void Start()
	{
		Player = GameObject.FindWithTag("Player").transform;
	}

	bool Visibility(GameObject checkObj)
	{
		float distance;

		if (checkObj != null)
		{
			distance = Vector3.Distance(Player.position, checkObj.transform.position);

			if (distance >= renderDistance)
				return false;
		}

		return true;
	}

	private void Update()
	{
		if (Player == null)
			return;
		if (Time.time >= nextCheck)
		{
			nextCheck = Time.time + checkRate;

			for (int o = 0; o < sceneObjects.Length; o++)
			{
				GameObject currentObject = sceneObjects[o];
				currentObject.SetActive (Visibility(currentObject));
			}
		}
	}
}