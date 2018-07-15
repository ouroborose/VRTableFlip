using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableComponentBehavior : MonoBehaviour {

    public Vector3 componentVelocity;
    const float minVelocity = 2f;
    TrailRenderer[] trails;
    bool shouldShowTrail;
    float trailTime = .25f;

    // Use this for initialization
    void Start () {
        trails = GetComponentsInChildren<TrailRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        componentVelocity = GetComponent<Rigidbody>().velocity;
        shouldShowTrail = componentVelocity.magnitude >= minVelocity;

        trailTime = Mathf.Lerp(trailTime, shouldShowTrail ? 0.25f : 0f, Time.deltaTime * 2);

        for (int i = 0; i < trails.Length; i++)
        {
            trails[i].enabled = trailTime > 0.1f;

            trails[i].time = trailTime;
        }
        
	}
}
