using UnityEngine;
using UnityEngine.UI;

public class CountCookies : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		if (PlayerPrefs.GetInt("Cookies", 0) == 0)
			PlayerPrefs.SetInt("Cookies", 0);
		GetComponent<Text>().text = "Cookies awarded : " + PlayerPrefs.GetInt("Cookies");
	}
}
