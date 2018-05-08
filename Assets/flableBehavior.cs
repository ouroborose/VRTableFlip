using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flableBehavior : MonoBehaviour {

    public GameObject flableRagdoll;
    public bool hasTipped = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Tip ()
    {
        if (hasTipped == false)
        {
            hasTipped = true;
            print("Flable has been tipped");
            Instantiate(flableRagdoll, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
