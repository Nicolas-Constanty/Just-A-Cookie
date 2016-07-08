using UnityEngine;

public class anim_weapon : MonoBehaviour {

	// Use this for initialization
	void Update ()
	{
		GetComponent<Animator>().SetBool("move", GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetBool("move"));
	}
}
