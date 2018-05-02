using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBehavior : MonoBehaviour {

    //store table1 start positions
    public Rigidbody tableRigidBody;

    public Vector3 originalPosition;
    public Vector3 originalVelocity;
    public Quaternion originalRotation;

    // Use this for initialization
    void Start () {

        originalPosition = transform.position;
        originalVelocity = tableRigidBody.velocity;
        originalRotation = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetTable ()
    {
        print("hiiii");
        transform.position = originalPosition;
        tableRigidBody.velocity = originalVelocity;
        transform.rotation = originalRotation; 
        
    }
}
