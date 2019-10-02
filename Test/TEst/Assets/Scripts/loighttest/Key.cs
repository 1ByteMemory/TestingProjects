using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public Light lightSpot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "door")
        {
            lightSpot.intensity = 10;
            Destroy(collision.transform.gameObject);
            Destroy(gameObject);
        }
    }
}
