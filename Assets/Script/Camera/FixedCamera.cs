using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedCamera : MonoBehaviour {

    private Vector3 fixedPos = new Vector3(0, 5, 12);

    private Transform mainRole;
	// Use this for initialization
	void Awake ()
    {
        mainRole = GameObject.FindGameObjectWithTag("Player").transform;	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (mainRole == null)
            return;

        transform.position = mainRole.position + fixedPos;


    }
}
