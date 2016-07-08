using UnityEngine;
using System.Collections;

public class spawn_egg : MonoBehaviour {

	public float time = 0.5f;
	public GameObject projectile;
	private int count = 0;
	private bool activate = false;
	// Update is called once per frame
	void Update () 
	{
		if (!activate && count < 3 && GameObject.FindGameObjectWithTag ("Scout").GetComponent<Animator> ().GetInteger ("anim") == 2) 
			StartCoroutine (fire ());
	}
	IEnumerator fire()
	{
		count++;
		activate = true;
		Instantiate (projectile, transform.position, Quaternion.identity);
		yield return new WaitForSeconds (time);
		activate = false;
	}
}
