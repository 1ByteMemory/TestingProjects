using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBounce : MonoBehaviour
{
    public GameObject prefab;
    public float shineSpeed = 5;

    
    public bool isHit;
    
    public GameObject hitObject;

    bool isNewBeam;
    RaycastHit rayHitInfo;

    Transform lightEnd;
    float lightEndStartRadius;

    GameObject newBeam;
    


    // Start is called before the first frame update
    void Start()
    {
        isHit = false;
        isNewBeam = false;
        hitObject = null;

        
        lightEnd = transform.GetChild(1);

        /// --!!-- THIS IS HARD CODED, SOFT CODE IT WHEN NOT PROTOTYPE --!!-- ///
        lightEnd.GetComponent<SphereCollider>().radius = 0.2f;


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

        if (isHit && hitObject != null && hitObject.tag == "mirror" && !isNewBeam)
        {
            isNewBeam = true;

            Vector3 lightPos = lightEnd.position;
            Vector3 localForward = lightEnd.TransformDirection(Vector3.forward);

            if (Physics.Raycast(lightPos, localForward, out rayHitInfo, 2))
            {
                Vector3 normal = rayHitInfo.normal;

                Vector3 reflect = Vector3.Reflect(localForward, normal);
                
                newBeam = Instantiate(prefab, lightEnd.position, transform.rotation);
                newBeam.transform.rotation = Quaternion.LookRotation(reflect);
                newBeam.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            }
        }
    }
}
