using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableExitManager : MonoBehaviour
{
    public string NextSceneName;

    protected bool m_sceneIsLoading = false;

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
        if(m_sceneIsLoading)
        {
            return;
        }

        if (other.gameObject.CompareTag("Table"))
        {
            //print("the table has left the trigger");
            //SteamVR_LoadLevel.Begin(NextSceneName);
            m_sceneIsLoading = true;
            StartCoroutine(LoadNextScene());

        }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(2.0f);
        OVRSceneLoader.LoadSceneViaLoadingScene(NextSceneName);

    }
}
