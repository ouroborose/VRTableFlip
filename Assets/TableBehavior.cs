using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBehavior : MonoBehaviour
{

    //store table1 start positions
    public Rigidbody tableRigidBody;

    public Vector3 originalPosition;
    public Vector3 originalVelocity;
    public Quaternion originalRotation;

    public bool isBreakable;
    public bool hasBroken = false;
    public GameObject brokenTable;

    public GameLogic gameLogic;

    // Use this for initialization
    void Start()
    {

        originalPosition = transform.position;
        originalVelocity = tableRigidBody.velocity;
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetTable()
    {
        print("Tables are now reset");
        transform.position = originalPosition;
        tableRigidBody.velocity = originalVelocity;
        transform.rotation = originalRotation;
        hasBroken = false;
        gameObject.SetActive(true);
        //search in scene for all broken tables and remove them
    }

    public void ThrowTable()
    {
        //tableRigidBody.AddForce(handCurrentVelocity, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Flable"))
        {
            if (isBreakable == true && hasBroken == false) // this doens't always hit.. investigate
            {
                print("HIT");
                hasBroken = true;
                Instantiate(brokenTable, transform.position, transform.rotation);
                gameObject.SetActive(false);
                collision.gameObject.GetComponent<flableBehavior>().Tip();
                gameLogic.IncrementScore(collision.gameObject.GetComponent<flableBehavior>().flableScore);
            }
        }
    }
}
