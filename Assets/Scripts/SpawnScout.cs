using UnityEngine;

public class SpawnScout : MonoBehaviour {

	public GameObject [] scoutPrefab;

	void Start () 
	{
		GameObject go;
		int rnd;
		go = (GameObject) Instantiate(scoutPrefab[rnd = Random.Range(0, scoutPrefab.Length)], transform.position, Quaternion.identity);
		if (rnd == 1)
			go.transform.position += new Vector3(0, 0.2f, 0);
	}
}
