using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRoleMove : MonoBehaviour {

    private int speed = 10;

    private Vector3 helpVec = new Vector3();

    private Rigidbody rigBody;

    private void Awake()
    {
        rigBody = this.transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update ()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        helpVec.x = h * speed;
        helpVec.y = rigBody.velocity.y;
        helpVec.z = v * speed;


        rigBody.velocity = helpVec;

    }
}
