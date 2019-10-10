using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    public bool isActivate;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        isActivate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivate)
        {
            isActivate = false;
            Vector3 spawnPos = transform.position + transform.TransformDirection(new Vector3 (0,0,0.5f));
            GameObject newObject = Instantiate(prefab, spawnPos, transform.rotation);
            
        }
    }
}
