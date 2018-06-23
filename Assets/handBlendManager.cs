using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handBlendManager : MonoBehaviour {
    public float closedAmount;
    public GameObject hand;
    Animator handAnimator;

	// Use this for initialization
	void Start () {
        handAnimator = hand.GetComponent<Animator>();
        //closedAmount = handAnimator.GetFloat("Blend");
	}
	
	// Update is called once per frame
	void Update () {
        handAnimator.SetFloat("Blend", closedAmount);
	}
}
