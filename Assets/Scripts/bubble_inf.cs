using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bubble_inf : MonoBehaviour {

	public float duration = 0.5f;
	private GameObject canvas;
	public AudioClip sound;
	public GameObject src;
	public GameObject parent;
	private bool activate = false;
	void Update ()
	{
		if (canvas)
		{
			canvas.transform.position = transform.position;

			if (activate)
				canvas.transform.localScale = Vector3.Lerp (canvas.transform.localScale, Vector3.one * 0.02f, 4 * Time.deltaTime);
		}
	}
	public void show(Sprite spr)
	{
		if (canvas)
			Destroy (canvas);
		canvas = (GameObject)Instantiate (src, transform.position, transform.rotation);
		canvas.transform.SetParent(transform);
		canvas.AddComponent<AudioSource>().clip = sound;
		canvas.GetComponent<AudioSource>().PlayOneShot(sound);
		canvas.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = spr;
		canvas.transform.localScale = Vector3.zero;
		StartCoroutine (died());
	}



	IEnumerator died()
	{
		activate = true;
		yield return new WaitForSeconds(0.5f);
		activate = false;
		duration -= 0.5f;
		if (duration < 0)
			duration = 0;
		yield return new WaitForSeconds(duration);
		Destroy(canvas);
	}
}
