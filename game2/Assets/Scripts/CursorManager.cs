using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Gun gun;
    [SerializeField] private Texture2D cursorNomal;
    [SerializeField] private Texture2D cursorShoot;
    [SerializeField] private Texture2D cursorReload;
    private Vector2 hostpost = new Vector2(16, 48);
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorNomal, hostpost, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(cursorShoot, hostpost, CursorMode.Auto);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(cursorNomal, hostpost, CursorMode.Auto);
        }
        if(Input.GetKeyDown(KeyCode.R) ||(Input.GetMouseButtonDown(0) && gun.IsReloading == true))
        {
            Cursor.SetCursor(cursorReload, hostpost, CursorMode.Auto);
        }
    }
}
