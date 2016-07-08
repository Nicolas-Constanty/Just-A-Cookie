using UnityEngine;
using System.Collections;

public class active_fire1 : MonoBehaviour {

	// Use this for initialization
	private bool play_one = false;
	void Start()
	{
		GetComponent<ParticleSystem> ().Stop();
	}
	IEnumerator play()
	{
		play_one = true;
		GetComponent<ParticleSystem> ().Play ();
		yield return new WaitForSeconds (1.5f);
		GetComponent<ParticleSystem> ().Stop();
	}
	// Update is called once per frame
	void Update () {
		if (!play_one && GameObject.FindGameObjectWithTag("Scout").GetComponent<Animator> ().GetInteger ("anim") == 3)
			StartCoroutine (play ());
	}
}
