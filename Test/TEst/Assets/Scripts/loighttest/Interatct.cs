using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interatct : MonoBehaviour
{

    GameObject Object;
    RaycastHit hit;
    public Image image;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.transform.tag == "InteractObject")
            {

                Object = hit.transform.gameObject;

                image.color = Color.red;

                if (Input.GetButton("Fire1"))
                {
                    Object.transform.parent = transform;
                }
                if (Input.GetButtonUp("Fire1"))
                {
                    Object.transform.parent = null;
                }

            }
            else
                image.color = Color.white;
        }

    }
}
