using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ScoreDooberTextBehavior : MonoBehaviour {

    public TextMeshPro ScoreText;
    public static int scoreValue;

	// Use this for initialization
	void Start () {
        
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Camera.main.transform);
	}

    void Awake ()
    {
        ScoreText.CrossFadeAlpha(1, 0, false);
        ScoreText = GetComponentInChildren<TextMeshPro>();
        ScoreText.SetText(scoreValue.ToString());
        ScoreText.transform.DOMove(new Vector3(ScoreText.transform.position.x, ScoreText.transform.position.y + .8f, ScoreText.transform.position.z)+Random.insideUnitSphere*.5f, 1);
        //ScoreText.CrossFadeAlpha(0.5f, .5f, false);
        Destroy(gameObject, 1.5);

    }
}
