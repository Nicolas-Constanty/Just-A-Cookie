using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]

public class Drag : MonoBehaviour {

	public obj thisObj = new obj();
	private Vector3 screenPoint;
	//private Vector3 offset;
	private Vector3 originalPos;
	private Vector3 refVel;
	bool selfDragged = false;

	void Start()
	{
		InventoryHandler.isDragged = false;
		originalPos = transform.position;
	}

	void OnMouseDown()
	{
		InventoryHandler.isDragged = true;
		selfDragged = true;
		GameObject.Find("Inventory").GetComponent<InventoryHandler>().StartCoroutine("fadeWarning");
		GetComponent<SpriteRenderer> ().sortingOrder = 10;
		//offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}

	void OnMouseUp()
	{
		GetComponent<SpriteRenderer> ().sortingOrder = 0;
		InventoryHandler inventory = GameObject.Find("Inventory").GetComponent<InventoryHandler>();
		InventoryHandler.isDragged = false;
		GameObject old_obj = GameObject.Find (inventory.oldObj.name);
		selfDragged = false;
		inventory.StopAllCoroutines();
		inventory.resetWarning();
		thisObj.index = inventory.index_drop;
		if (inventory.canBeDropped)
		{
			if (inventory.oldObj.name != "empty" && old_obj.GetComponent<Collider2D>().enabled == false)
			{
				old_obj.GetComponent<Collider2D>().enabled = true;
				StopCoroutine("fadetexture");
				StartCoroutine(fadetexture(old_obj));
				old_obj.GetComponent<SpriteRenderer>().enabled = true;
			}
			inventory.addObject(thisObj);
			gameObject.GetComponent<Collider2D>().enabled = false;
			//GameObject.Find("Spawn_info").GetComponent<bounce_info>().create_info_bulle(this.GetComponent<SpriteRenderer>().sprite);
			GameObject.Find("Spawn_info").GetComponent<bubble_inf>().show(GetComponent<SpriteRenderer>().sprite);
		}
	}

	void Update()
	{
		if (selfDragged == false)
		{
			transform.position = Vector3.SmoothDamp(transform.position, originalPos, ref refVel, 0.4f);
			return;
		}
		Vector3 worldCoorMin = Camera.main.ScreenToWorldPoint(new Vector3 (0, 0, 0));
		Vector3 worldCoorMax = Camera.main.ScreenToWorldPoint(new Vector3 (Screen.width, Screen.height, 0));
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, worldCoorMin.x, worldCoorMax.x),
		                                      Mathf.Clamp(transform.position.y, worldCoorMin.y, worldCoorMax.y), 0);
	}

	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);// + offset;
		//transform.position = curPosition;
		transform.position = Vector3.SmoothDamp(transform.position, curPosition, ref refVel, 0.1f);
	}

	public void SendImage()
	{
		InventoryHandler inventory = GameObject.Find("Inventory").GetComponent<InventoryHandler>();
		if (!selfDragged)
			return;
		GetComponent<SpriteRenderer>().enabled = false;
		thisObj.index = inventory.index_drop;
		inventory.addObject(thisObj);
	}

	public void DeleteImage()
	{
		InventoryHandler inventory = GameObject.Find("Inventory").GetComponent<InventoryHandler>();
		if (!selfDragged)
			return;
		GetComponent<SpriteRenderer>().enabled = true;
		inventory.restoreObj(thisObj.index);
	}

	public IEnumerator fadetexture(GameObject old_obj)
	{
		float i = 0;
		old_obj.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
		while (i < 1)
		{
			old_obj.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, i);
			yield return new WaitForSeconds(0.1f);
			i += 0.1f;
		}
	}
}