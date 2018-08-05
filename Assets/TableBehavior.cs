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

    public bool isBreakable = true;
    public bool hasBroken = false;
    public GameObject brokenTable;

    public GameLogic gameLogic;

    public FixedJoint[] tableJoints;

    // Use this for initialization
    void Start()
    {
        tableJoints = GetComponentsInChildren<FixedJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        //if at any point the fixed joint breaks WHILE the table is outside the trigger, then add to score

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

    void OnCollisionExit(Collision collision)
    {
        //print("Hey this table has left the bounds");
        if (collision.gameObject.CompareTag("TableBounds"))
        {
            print("HIT");
            //hasBroken = true;
            //Instantiate(brokenTable, transform.position, transform.rotation);
            //gameObject.SetActive(false);
            //collision.gameObject.GetComponent<flableBehavior>().Tip();
            //gameLogic.IncrementScore(collision.gameObject.GetComponent<flableBehavior>().flableScore);
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.gameObject.CompareTag("TableBounds"))
        {
            print("the table has left the trigger");
            /*if(hasBroken == false)
            {
                print("the table has left the trigger");
                hasBroken = true;
                Vector3 tempTableVel = tableRigidBody.velocity;
                Vector3 tempTableAngVel = tableRigidBody.angularVelocity;
                GameObject newBrokenTable = Instantiate(brokenTable, transform.position, transform.rotation);
                Rigidbody[] tableParts = newBrokenTable.GetComponentsInChildren<Rigidbody>();

                for (int i = 0; i < tableParts.Length; i++)
                {
                    tableParts[i].velocity = tempTableVel;
                    tableParts[i].angularVelocity = tempTableAngVel;
                }
                
                gameObject.SetActive(false);
            }*/

        }
    }


}
