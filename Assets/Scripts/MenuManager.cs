using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void loadIntro()
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

	public void Quit()
	{
#if UNITY_WEBPLAYER
		Application.ExternalEval("window.close()");
#else
		Application.Quit();
#endif
	}
}
