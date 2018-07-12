using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBoundary : MonoBehaviour {

    public GameObject brokenTable;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Table"))
        {
            if (other.gameObject.GetComponent<TableBehavior>().isBreakable == true && other.gameObject.GetComponent<TableBehavior>().hasBroken == false)
            {
                print("HIT");
                other.GetComponent<TableBehavior>().hasBroken = true;
                Instantiate(brokenTable, other.transform.position, other.transform.rotation);
                other.gameObject.SetActive(false);
            }
        }
    }

}
