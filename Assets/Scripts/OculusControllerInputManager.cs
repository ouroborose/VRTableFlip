using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusControllerInputManager : MonoBehaviour {
    public SteamVR_TrackedObject trackedObj;

    [SerializeField]
    protected OVRInput.Controller m_controller;

    public OVRInput.Button buttonToTeleport = OVRInput.Button.Four;

    [SerializeField]
    private AudioClip m_playerDamageClip;

    private OVRHapticsClip m_hapticsClipPlayerDamage;

    //Teleporter variables
    private LineRenderer laser;
    public LineRenderer debugLine;
    public Material laserMat;
    public GameObject teleportAimerObject;
    public Vector3 teleportLocation;
    public GameObject player;
    public LayerMask laserMask;
    public int teleportDistance = 5; // in meters
    //public LayerMask unteleportable;
    public float yNudgeAmount = 0.5f; //specific to telportAimerObject height
    public GameObject levelHint;
    public GameLogic gameLogic;
    public GameObject handMenu;

    //debug purposes
    public GameObject someNewObject;
    public GameObject headObject;



    // Use this for initialization
    void Start () {
        laser = GetComponentInChildren<LineRenderer>();

	}
	
	// Update is called once per frame
	void Update () {

        //teleport Stuff

        if(OVRInput.Get(buttonToTeleport)) // Y button on left controller
        {
            laser.gameObject.SetActive(true);
            teleportAimerObject.SetActive(true);

            laser.SetPosition(0, gameObject.transform.position);
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, teleportDistance, laserMask))
            //creates a ray from the controller position in the forward direction of the controller
            //outputs a hit object and has a max range of x meters can only collide with laserMask
            {
                
                teleportLocation = hit.point;
                laser.SetPosition(1, teleportLocation);
                Debug.Log("raycast hit laserMask at a height of: " + teleportLocation.y + " plus a yNudge amount of" + yNudgeAmount + " =" + (teleportLocation.y+yNudgeAmount));
                // moves the cylinder to the hit position
                teleportAimerObject.transform.position = new Vector3(teleportLocation.x, teleportLocation.y + yNudgeAmount, teleportLocation.z);

                //rotate so it faces the player's hand
                teleportAimerObject.transform.eulerAngles = new Vector3(0, gameObject.transform.eulerAngles.y, 0);
            }

            else // if the raycast does not hit the lasermask position
            {
                
                Debug.Log("raycast reached end and is now raycasted to the ground");
                Vector3 endOfLaser = transform.position + transform.forward * teleportDistance;
                debugLine.SetPosition(0, endOfLaser);
                debugLine.SetPosition(1, endOfLaser + new Vector3(0, -30, 0));
                teleportLocation = endOfLaser;
                RaycastHit groundRayHit; // new raycast from the end of the laser to the ground
                if (Physics.Raycast(teleportLocation, -Vector3.up, out groundRayHit, 10, laserMask))
                {
                    // if that second raycast hits the ground, teleport there
                    teleportLocation = groundRayHit.point + new Vector3(0, yNudgeAmount, 0);
                    //teleportLocation = new Vector3(transform.forward.x * teleportDistance + transform.position.x, groundRayHit.point.y, transform.forward.z * 15 + transform.position.z);
                    
                }

                else // if the teleport laser is pointed completely out of the play area
                {
                    Debug.Log("all other cases");

                    Vector3 playerHeadOffset = player.transform.position - headObject.transform.position;
                    playerHeadOffset.y = 0;
                    teleportLocation = player.transform.position - playerHeadOffset;
                    
                }

                laser.SetPosition(1, transform.forward * 15 + transform.position);
                //aimer position
                teleportAimerObject.transform.position = teleportLocation;
                
            }
        }

        if(OVRInput.GetUp(buttonToTeleport)) // getPressUp = button is released
        {
            Debug.Log("teleported to " + teleportAimerObject.transform.position.y);
            laser.gameObject.SetActive(false);
            teleportAimerObject.SetActive(false);
            Vector3 playerHeadOffset = player.transform.position - headObject.transform.position;
           playerHeadOffset.y = 0;
                // vive space position - player camera position
            player.transform.position = teleportAimerObject.transform.position + playerHeadOffset;
            
        }
        // hand menu
        if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            print("Menu is open");
            handMenu.SetActive(true);
        }

        if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger)) 
        {
            print("Menu is closed");
            handMenu.SetActive(false);
        }
    }
}
