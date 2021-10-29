using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTexture : MonoBehaviour
{
	public Texture2D idle_cursor;

	// Start is called before the first frame update
	void Start()
    {
		Cursor.SetCursor(idle_cursor, Vector2.zero, CursorMode.ForceSoftware);
    }

}
