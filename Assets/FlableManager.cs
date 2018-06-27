using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlableManager : MonoBehaviour {

    public float numberOfFlables;
    public float flableHealth;
    public GameObject flable;
    public float spawnDelay;
    
    public Vector3 spawnCenter;
    public Vector3 spawnRange;


	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnFlable(flable, spawnDelay));
	}

    IEnumerator SpawnFlable(GameObject flable, float delay)
    {
        for (int i = 0; i < numberOfFlables; i++)
        {
            Vector3 spawnPosition = spawnCenter + new Vector3(Random.Range(-spawnRange.x / 2, spawnRange.x / 2), Random.Range(0, spawnRange.y / 2), Random.Range(-spawnRange.z / 2, spawnRange.z / 2));
            GameObject newFlable = Instantiate(flable, spawnPosition, Quaternion.identity);
            newFlable.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].color = Random.ColorHSV(0f, 1f, 0f, 0.7f, 1f, 1f);

            yield return new WaitForSeconds(delay);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
