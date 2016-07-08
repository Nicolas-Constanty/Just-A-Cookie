using UnityEngine;
using System.Collections;

public class active_fire : MonoBehaviour {

	private bool play_one = false;
	// Update is called once per frame
	void Awake()
	{
		GetComponent<ParticleSystem> ().Stop();
	}
	void Update ()
	{
		if (!play_one && GetComponentInParent<Animator> ().GetInteger ("anim") == 3)
			StartCoroutine (play ());
	}
	IEnumerator play()
	{
		play_one = true;
		GetComponent<ParticleSystem> ().Play ();
		yield return new WaitForSeconds (1.5f);
		GetComponent<ParticleSystem> ().Stop();
	}
}
