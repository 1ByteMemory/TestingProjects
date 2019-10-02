using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookScript : MonoBehaviour
{
    Camera cam;
    Rigidbody rb;

    Vector3 CamPos
    {
        get { return cam.transform.localPosition; }
        set { cam.transform.localPosition = value; }
    }

    float camY, camZ;

    public float Ysensitivity = 2;
    public float Xsensitivity = 2;
    public float cameraDistance = 6;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookAngle = cam.transform.localEulerAngles;

        if (!Cursor.visible)
        {
            float MouseY = Input.GetAxisRaw("Mouse Y") * Ysensitivity;
        }
    }
}
/*


if (Input.GetAxisRaw("Mouse Y") != 0)
{
    float MouseY = Input.GetAxisRaw("Mouse Y") * Ysensitivity;

    camY -= MouseY;
    if (camY > cameraDistance)
        camY = cameraDistance;
    if (camY< -cameraDistance)
        camY = -cameraDistance;

    float y = Mathf.Abs(Mathf.Pow(camY, 2));
    camZ = Mathf.Sqrt(Mathf.Abs(Mathf.Pow(cameraDistance, 2) - y));

    if (camZ< 1)
        camZ = 1;
                
    CamPos = new Vector3(0, camY, camZ);
}

// Rotates player left and right.
transform.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X") * Xsensitivity);

*/
