using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonTracking : MonoBehaviour
{

    public float speed = 1.0f;
    private GameObject target = null;
    Vector3 lastPos = Vector3.zero;
    private Quaternion lookrotation;
    public Transform spawn;
    public float fireRate = 5.0F;
    private float nextFire = 0.0F;
    public GameObject [] go ;
    private GameObject projec;

    void Start()
    {
        projec = go[1];
        target = go[0];
    }

    void Update () {
	    if (lastPos != target.transform.position)
	    {
	        lastPos = target.transform.position;
	        lookrotation = Quaternion.LookRotation(lastPos - transform.position);
	    }

	    if (transform.rotation != lookrotation)
	    {
	        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookrotation, speed * Time.deltaTime);
	    }
	    else
	    {
	        Fire();
	    }

	}

    void Fire()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject clone = Instantiate(projec, spawn.position, spawn.rotation) as GameObject;
            clone.GetComponent<Rigidbody>().velocity = clone.transform.forward * 30;
            Destroy(clone, 5.0f);
        }
    }
}
