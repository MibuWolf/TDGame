using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRoleMove : MonoBehaviour {

    private int speed = 8;

    private Vector3 helpVec = new Vector3();

    private Rigidbody rigBody;

    private Animator animator;

    private Vector3 helpRot = new Vector3();

    private void Awake()
    {
        rigBody = this.transform.GetComponent<Rigidbody>();
        animator = this.transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        helpVec.x = -h * speed;
        helpVec.y = rigBody.velocity.y;
        helpVec.z = -v * speed;

        helpRot.x = -h;
        helpRot.y = 0;
        helpRot.z = -v;

        rigBody.velocity = helpVec;

        if (rigBody.velocity.magnitude > 0.01f)
            animator.SetBool("Run", true);
        else
            animator.SetBool("Run", false);

        if( Mathf.Abs( h ) > 0.01f || Mathf.Abs( v ) > 0.01f)
            transform.rotation = Quaternion.LookRotation(helpRot);
    }
}
