using UnityEngine;

public class Change_cursor : MonoBehaviour {

	public Texture2D texture_over;
	public Texture2D texture_click;
	
	void OnMouseEnter()
	{
		Cursor.SetCursor (texture_over, Vector2.zero, CursorMode.Auto);
	}
	void OnMouseExit()
	{
		Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
	}
	void OnMouseDown()
	{
		Cursor.SetCursor (texture_click, Vector2.zero, CursorMode.Auto);
	}
	void OnMouseUp()
	{
		Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
	}
}
