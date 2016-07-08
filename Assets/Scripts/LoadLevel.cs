using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

	public void LoadGame()
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	void Update()
	{
		if (Input.anyKeyDown)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
