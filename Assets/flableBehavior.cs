using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flableBehavior : MonoBehaviour {

    public GameObject flableRagdoll;
    public bool hasTipped = false;
    public int flableScore = 1000;

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
