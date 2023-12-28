using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D Texture2D;
    private void Start()
    {
        Cursor.SetCursor(Texture2D,Vector2.zero,CursorMode.Auto);
    }
}
