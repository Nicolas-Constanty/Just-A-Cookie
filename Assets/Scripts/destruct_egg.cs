using UnityEngine;

public class destruct_egg : MonoBehaviour {

	public GameObject destroy_ouef;
	// Use this for initialization
	void Update ()
	{
		transform.Translate (-8 * Time.deltaTime, 0, 0);
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		Instantiate (destroy_ouef, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
