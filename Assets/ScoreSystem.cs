using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour {


    public static int score = 0;
    public TextMeshPro scoreText;
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        scoreText.SetText("score: " + score.ToString());
		
	}
    
}
