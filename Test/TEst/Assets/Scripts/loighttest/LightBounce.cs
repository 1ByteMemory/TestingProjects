using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBounce : MonoBehaviour
{

    public float shineSpeed = 5;

    [HideInInspector]
    public bool isHit = false;
    [HideInInspector]
    public GameObject hitObject;

    bool newBeam = false;
    RaycastHit rayHitInfo;

    public GameObject lightEnd;
    float lightEndStartRadius;

    float hitAngle;
    
    // Start is called before the first frame update
    void Start()
    {
        lightEndStartRadius = lightEnd.GetComponent<SphereCollider>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isHit)
        {
            transform.localScale += new Vector3(0, 0, Time.deltaTime * shineSpeed);
            lightEnd.GetComponent<SphereCollider>().radius = lightEndStartRadius / transform.localScale.z;
        }

        if (transform.localScale.z > 30)
        {
            isHit = true;
            hitObject = null;
        }

        if (isHit && hitObject != null && hitObject.tag == "mirror" && !newBeam)
        {
            newBeam = true;
            
            NewAngle(transform.position, lightEnd.transform.position);

            // <<<------ Calculate bounce off angle ------->>> //

        }
    }



    void NewAngle(Vector3 pointA, Vector3 pointB)
    {
        float Adj, Opp;

        // Opposite is always set as the hieght difference
        if (pointA.y > pointB.y)
            Opp = pointA.y - pointB.y;
        else if (pointB.y > pointA.y)
            Opp = pointB.y - pointA.y;
        else
            Opp = 0;

        if (Opp != 0)
        {
            // Pythagoras theroum is used to calculate the Adjasent
            // (The defference bewteen the x and z coords)
            Adj = Mathf.Sqrt(Mathf.Pow(pointB.x - pointA.x, 2) + Mathf.Pow(pointB.z - pointA.z, 2));

            float radians = Mathf.Atan(Opp / Adj);
            hitAngle = radians * (180 / Mathf.PI);
        }
        else
        {
            hitAngle = 0;
        }
    }
}
