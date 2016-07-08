using UnityEngine;
public class AnimCloud : MonoBehaviour {

	public float velocity = 0.001f;

	void Update () 
	{
		GetComponent<MeshRenderer>().material.mainTextureOffset += new Vector2(velocity, 0);
	}
}
