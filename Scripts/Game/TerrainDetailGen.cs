using UnityEngine;

public class TerrainDetailGen : MonoBehaviour {

	public float minX;
	public float minZ;
	public float maxX;
	public float maxZ;

	public bool spawnTrees = true;
	public int maxTrees = 1000;
	public GameObject treePrefab;
	public float minTreeSize = 0.75f;
	public float maxTreeSize = 1.15f;

	private int spawnedTrees = 0;

	private RaycastHit hitInfo;

	private void Update()
	{
		GenerateTrees();
	}

	private void GenerateTrees ()
	{
		for (int i = 0; i < maxTrees; i++)
		{
			float x = Random.Range(minX, maxX);
			float z = Random.Range(minZ, maxZ);

			Ray ray = new Ray(new Vector3(x, 100000f, z), Vector3.down);
			RaycastHit hitInfo;

			if (Physics.Raycast(ray, out hitInfo))
			{
				GameObject spawnedTreeObj = Instantiate(
					treePrefab,
					hitInfo.point,
					Quaternion.Euler(-90f, Random.Range(0, 18) * 10, 0f),
					this.transform);

				float scale = Random.Range(minTreeSize, maxTreeSize);
				spawnedTreeObj.transform.localScale = new Vector3(scale, scale, scale);

				spawnedTrees++;
			}
		}
	}
}