using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroardCastHit : MonoBehaviour
{


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag != "lightBeam")
        {
            
            GetComponentInParent<LightBounce>().isHit = true;
            GetComponentInParent<LightBounce>().hitObject = other.transform.gameObject;
        }
    }
}
