using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public void LoadScene (int _index)
	{
		SceneManager.LoadSceneAsync(_index);
	}

	public void Shutdown ()
	{
		Application.Quit();
	}
}