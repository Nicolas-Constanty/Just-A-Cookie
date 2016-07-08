using UnityEngine;
using System.Collections;

public class ChangeRoom : MonoBehaviour {

	public bool moveRight = false;
	public bool moveLeft = false;
	private Vector3 init;
	public bool transition = false;
	private float target = 10000;
	private bool oncollide = false;
	
	void Update ()
	{

		if (GetComponent<Animator> ().GetBool ("action"))
			DontMove ();
		if (Input.GetMouseButtonDown (0) && !transition && !GetComponent<Animator>().GetBool("action"))
		{
			target = Camera.main.ScreenToWorldPoint (Input.mousePosition).x;
		}
		if (!GameObject.Find ("workshop").GetComponent<Atelier> ().click)
		{
			if (Mathf.Abs (transform.position.x - target) <= 0.5f)
				DontMove ();
			else if (!oncollide) {
				if (target != 10000) {
					if (transform.position.x > target)
						MoveLeft ();
					else
						MoveRight ();
				}
			}
		}
		if (moveLeft && !moveRight)
		{
			GetComponent<Animator>().SetBool("move", true);
			transform.localScale = new Vector3(1, 1, 1);
			transform.Translate(-4 * Time.deltaTime, 0, 0);
		}
		if (!moveLeft && moveRight)
		{
			GetComponent<Animator>().SetBool("move", true);
			transform.localScale = new Vector3(-1, 1, 1);
			transform.Translate(4 * Time.deltaTime, 0, 0);
		}
	}

	public void MoveLeft()
	{
		moveLeft = true;
		moveRight = false;
	}

	public void MoveRight()
	{
		moveRight = true;
		moveLeft = false;
	}

	public void DontMove()
	{
		moveRight = false;
		moveLeft = false;
		GetComponent<Animator>().SetBool("move", false);
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		oncollide = true;
		if (col.tag == "Door" && transform.localScale.x == 1)
			StartCoroutine(wait(col, -1));
		else if (col.tag == "Door" && transform.localScale.x == -1)
			StartCoroutine(wait(col, 1));
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Door")
			StartCoroutine (wait_end ());
	}
	IEnumerator wait(Collider2D col, int sign)
	{
		transition = true;
		DontMove();
		target = 10000;
		Camera.main.GetComponent<FadeTransition>().StartCoroutine("Fade", col.GetComponent<door>().roomToGo);
		yield return new WaitForSeconds (1);
		transform.position = col.GetComponent<door>().exit.transform.position;
		yield return new WaitForSeconds (1);
		transition = false;
	}
	IEnumerator wait_end()
	{
		yield return new WaitForSeconds(1);
		oncollide = false;
	}
}
