using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlableRagdollBehavior : MonoBehaviour {

    public Rigidbody[] ragdollRigidbodies;

	// Use this for initialization
	void Start () {
        ragdollRigidbodies = gameObject.GetComponentsInChildren<Rigidbody>();
        StartCoroutine(KillFlable(2.0f));
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Awake ()
    {
        
    }

    void FixedUpdate ()
    {
        

        //Debug.DrawRay(ragdollRigidbody.position, ragdollRigidbody.velocity, Color.red, 10.0f);
    }

    IEnumerator KillFlable(float delay)
    {
        yield return new WaitForSeconds(delay);
        for (int i = 0; i < ragdollRigidbodies.Length; i++)
        {
            ragdollRigidbodies[i].isKinematic = true;
        }
        gameObject.GetComponentInChildren<Rigidbody>().transform.DOScale(0,2.0f);

        yield return new WaitForSeconds(2.0f);

        Destroy(gameObject);
    }
}
