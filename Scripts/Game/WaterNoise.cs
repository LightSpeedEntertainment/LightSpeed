using UnityEngine;

public class WaterNoise : MonoBehaviour {

	MeshFilter mf;
	public float strength = 5f;

	private void Start()
	{
		mf = GetComponent<MeshFilter>();
	}

	private void Update()
	{
		Vector3[] vertices = mf.mesh.vertices;

		for (int cV = 0; cV < vertices.Length; cV++)
		{
			float offset = Time.timeSinceLevelLoad;
			vertices[cV].y = Mathf.PerlinNoise(vertices[cV].x + offset, vertices[cV].z + offset) * strength;
		}

		mf.mesh.vertices = vertices;
		mf.mesh.RecalculateNormals();
	}
}