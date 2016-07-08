using UnityEngine;

public class door : MonoBehaviour {

	public GameObject exit;
	public string roomToGo = "none";
	void OnMouseDown()
	{
		GameObject.Find ("workshop").GetComponent<Atelier> ().click = false;
		if (!GameObject.FindGameObjectWithTag ("Player").GetComponent<ChangeRoom> ().transition)
		{
			if (GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ().position.x < transform.position.x)
				GameObject.FindGameObjectWithTag ("Player").GetComponent<ChangeRoom> ().MoveRight ();
			else
				GameObject.FindGameObjectWithTag ("Player").GetComponent<ChangeRoom> ().MoveLeft ();
		}
	}
}
