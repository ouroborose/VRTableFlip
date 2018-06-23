using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandModelBehavior : MonoBehaviour {

    private Vector3 lastPosition;
    private Vector3 currentPosition;
    public Vector3 targetVelocity;
    public Vector3 currentVelocity;

    public float maxVelocityChange = 8f;

    public GameObject currentTable;
    public Transform controllerObject;

    // rotation calculation stuff
    Quaternion rotationDelta;

    // Use this for initialization
    void Start () {
        this.GetComponentInChildren<Rigidbody>().maxAngularVelocity = 100;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        currentPosition = transform.position;
        currentVelocity = this.GetComponentInChildren<Rigidbody>().velocity;
        // controller's position minus my hand position
        targetVelocity = controllerObject.position - currentPosition;

        if (float.IsNaN(targetVelocity.x) == false)
        {
            this.GetComponentInChildren<Rigidbody>().velocity = Vector3.MoveTowards(currentVelocity, targetVelocity / Time.deltaTime, maxVelocityChange);
        }

        //Vector3.MoveTowards(this.Rigidbody.velocity, velocityTarget, MaxVelocityChange);

        float angle;
        Vector3 axis;

        rotationDelta = controllerObject.rotation * Quaternion.Inverse(this.transform.rotation);
        rotationDelta.ToAngleAxis(out angle, out axis);

        if (angle > 180)
            angle -= 360;

        Vector3 angularTarget = Mathf.Deg2Rad*angle * axis;

        if (float.IsNaN(angularTarget.x) == false)
        {
            this.GetComponentInChildren<Rigidbody>().angularVelocity = angularTarget / Time.deltaTime;
        }

        lastPosition = currentPosition;
    }

    /*void OnCollisionEnter(Collision collision)
    {
        currentTable = collision.gameObject;
        print("your hand touched soemthing");
        if (collision.rigidbody.CompareTag("ForceThrow"))
        {
            //currentTable.ThrowTable();
            collision.rigidbody.GetComponent<Rigidbody>().AddForce(Vector3.up*100, ForceMode.Impulse);
            print("Force throw table");
        }
    }*/
}
