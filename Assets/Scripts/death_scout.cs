using UnityEngine;

public class death_scout : MonoBehaviour {
	
	void Update ()
	{
		if (GameObject.FindWithTag("Player").GetComponent<Animator>().GetBool("weapon")
		    && Mathf.Abs(GameObject.FindWithTag("Player").transform.position.x - transform.position.x) <= GameObject.Find("workshop").GetComponent<Atelier>().s_distance)
			GetComponent<Animator>().SetInteger("anim", GameObject.Find("workshop").GetComponent<Atelier>().last_anim);
	}
}
