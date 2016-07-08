using UnityEngine;
using System.Collections;

public class ChienAttack : MonoBehaviour {

	GameObject target = null;
	public GameObject fire;
	bool isOnFire = false;

	void Start () 
	{
		target = GameObject.FindGameObjectWithTag("Scout");
	}
	
	void Update () 
	{
		if (Mathf.Abs(Vector2.Distance(transform.position, target.transform.position)) > 0.5f)
		{
			transform.position += Vector3.Lerp(transform.position, target.transform.position, 1) * 0.02f;
		}
		else if (!isOnFire)
		{
			isOnFire = true;
			fire.SetActive(true);
			StartCoroutine(startFading());
		}
	}

	IEnumerator startFading()
	{
		for (float i = 1; i >= -0.1; i-= 0.1f)
		{
			GetComponent<SpriteRenderer>().material.color = new Color(i, i, i, 1);
			yield return new WaitForSeconds(0.001f);
		}
		for (float i = 1; i >= -0.1; i-= 0.1f)
		{
			GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, i);
			yield return new WaitForSeconds(0.01f);
		}
	}
}
