using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class OculusHandInteraction : MonoBehaviour {

    public float throwForce = 1.5f;

    // Should be OVRInput.Controller.LTouch or OVRInput.Controller.RTouch.
    [SerializeField]
    protected OVRInput.Controller m_controller;

    public OVRInput.Button triggerButton;
    public OVRInput.Axis1D triggerAxis;

    // swipe variables
    public float swipeSum;
    public float touchLast;
    public float touchCurrent;
    public float distance;
    public bool hasPressedLeft;
    public bool hasPressedRight;
    public ObjectMenuManager objectMenuManager;
    public Component[] handColliders;

    //hand stuff
    public GameObject handObject;
    public GameObject currentlyTouchingTable;
    //public Color enabledColor = new Color(0, 255, 86, 255);
    //public Color disabledColor = new Color(80, 20, 86, 88);
    public Material enabledColor;
    public Material disabledColor;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.Get(triggerButton) == true)
        {
            // hands are now active
            handColliders = handObject.GetComponentsInChildren<Collider>();
            foreach (Collider collider in handColliders)
                collider.enabled = true;
            handObject.GetComponentInChildren<SkinnedMeshRenderer>().material = enabledColor;
            handObject.GetComponent<handBlendManager>().closedAmount = 0.7f * (OVRInput.Get(triggerAxis, OVRInput.Controller.Touch));
            
        }

        else if (OVRInput.Get(triggerButton) == false)
        {
            handColliders = handObject.GetComponentsInChildren<Collider>();
            foreach (Collider collider in handColliders)
                collider.enabled = false;
            // hands are now inactive
            // handObject.GetComponentInChildren<Collider>().enabled = false;
            handObject.GetComponentInChildren<SkinnedMeshRenderer>().material = disabledColor;
            handObject.GetComponent<handBlendManager>().closedAmount = 0f;
        }
    }

    void SpawnObject()
    {
        //objectMenuManager.SpawnCurrentObject();
    }

    void SwipeLeft()
    {
        //objectMenuManager.MenuLeft();
    }

    void SwipeRight()
    {
        //objectMenuManager.MenuRight();
    }

    void OnTriggerStay(Collider col)
    {

        if(col.gameObject.CompareTag("Throwable"))
        {
            //if (OVRInput.GetUp(triggerButton) == true)
            //{
                ThrowObject(col);
            //}
           // else if(OVRInput.GetDown(triggerButton) == true)
            //{
           //     GrabObject(col);
           // }
        }

        if (col.gameObject.CompareTag("Grabable"))
        {
            if (OVRInput.GetUp(triggerButton) == true)
            {
                DropObject(col);
            }
            else if (OVRInput.GetDown(triggerButton) == true)
            {
                GrabObject(col);
            }
        }

        if (col.gameObject.CompareTag("Flippable"))
        {
            handObject.GetComponent<Collider>().enabled = false;
            handObject.GetComponentInChildren<SkinnedMeshRenderer>().material = disabledColor;

            if (OVRInput.GetDown(triggerButton) == true)
            {
                FlipObject(col);
            }
        }
    }

    void GrabObject(Collider coli)
    {
        coli.transform.SetParent(gameObject.transform);
        coli.GetComponent<Rigidbody>().isKinematic = true;
        //device.TriggerHapticPulse(2000);
        //Debug.Log("you're pulling the trigger on an object");
    }

    void ThrowObject(Collider coli)
    {
        coli.transform.SetParent(null);
        Rigidbody rigidBody = coli.GetComponent<Rigidbody>();
        rigidBody.isKinematic = false;
        rigidBody.velocity = OVRInput.GetLocalControllerVelocity(m_controller) * throwForce;
        //rigidBody.angularVelocity = OVRInput.GetLocalControllerAngularVelocity(m_controller);
        rigidBody.angularVelocity = new Vector3(0,0,0);
        //Debug.Log("table is being thrown");
        //Debug.Log("you have released the trigger");

        // otherwise, if player is standing outside of the start zone, then color the ball red , make cheating boolean true
        //Ball ball = coli.GetComponent<Ball>();
       // ball.PlayerIsCheating();
    }

    void FlipObject(Collider coli)
    {
        //device.TriggerHapticPulse(500);
        coli.transform.SetParent(null);
        Rigidbody rigidBody = coli.GetComponent<Rigidbody>();
        rigidBody.isKinematic = false;
        rigidBody.velocity = OVRInput.GetLocalControllerVelocity(m_controller) * 2;
        rigidBody.angularVelocity = OVRInput.GetLocalControllerAngularVelocity(m_controller);
    }

    void DropObject(Collider coli)
    {
        coli.transform.SetParent(null);
    }
}
