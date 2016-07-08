using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevel : MonoBehaviour {

	public void ReloadLevelFunction()
	{
        SceneManager.LoadScene("Level1");
    }
}
