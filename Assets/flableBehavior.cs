using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flableBehavior : MonoBehaviour
{

    public GameObject flableRagdoll;
    public bool hasTipped = false;
    public int flableScore = 100;
    public float maxSpeed;
    public GameObject scoreDoober;
    private Vector3 explosionPos;
    public float explosionPower;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<TableComponentBehavior>() != null || collision.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("This flable has been hit!");
            explosionPos = collision.gameObject.GetComponentInChildren<Rigidbody>().position;
            Tip();
        }
    }

    public void Tip()
    {

        if (hasTipped == false)
        {
            hasTipped = true;
            Debug.Log("Flable has been tipped");
            GameObject flableRagdollObj = Instantiate(flableRagdoll, transform.position, transform.rotation);
            Vector3 ragdollVelocity = flableRagdollObj.GetComponentInChildren<Rigidbody>().velocity;
            //adds an explosion force to the ragdoll flable
            //flableRagdoll.GetComponentInChildren<Rigidbody>().AddExplosionForce(explosionPower, explosionPos, 3.0f);
            flableRagdollObj.GetComponentInChildren<Rigidbody>().AddExplosionForce(explosionPower, explosionPos, 3.0f);//AddForce(new Vector3(0f, explosionPower, 0f), ForceMode.VelocityChange);
            flableRagdollObj.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].color = gameObject.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].color;
            
            //ragdollVelocity = Vector3.ClampMagnitude(ragdollVelocity, maxSpeed);
            Debug.Log("flable velocity clamped to: " + ragdollVelocity);
            Destroy(gameObject);

            ScoreSystem.score += flableScore;
            ScoreDooberTextBehavior.scoreValue = flableScore;
            Instantiate(scoreDoober, transform.position, Quaternion.identity);
        }
    }
}
