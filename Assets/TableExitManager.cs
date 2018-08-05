using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableExitManager : MonoBehaviour
{
    public string NextSceneName;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Table"))
        {
            print("the table has left the trigger");
            //SteamVR_LoadLevel.Begin(NextSceneName);
            OVRSceneLoader.LoadSceneViaLoadingScene(NextSceneName);

        }
    }
}
