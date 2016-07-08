using UnityEngine;
using System.Collections;

public class FadeTransition : MonoBehaviour {

	public CameraPos [] camPos;

	[System.Serializable]
	public class CameraPos
	{
		public string roomName;
		public Transform position;
	}

	public IEnumerator Fade(string roomToGo)
	{
		GameObject.Find("PixelEffector").GetComponent<PixelEffector>().startTransition();
		GameObject.Find("Inventory").GetComponent<InventoryHandler>().hideInventory();
        yield return new WaitForSeconds(1.3f);
		foreach (CameraPos _camPos in camPos)
		{
			if (_camPos.roomName == roomToGo)
			{
				Camera.main.transform.position = _camPos.position.position + new Vector3(0, 0, -10);
			}
		}
    }
}
