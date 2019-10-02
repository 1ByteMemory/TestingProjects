using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int toggleCursor;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Break();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            toggleCursor++;
            ToggleCursor(toggleCursor);
        }
    }

    void ToggleCursor(int toggle)
    {
        if (toggle % 2 == 0)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
