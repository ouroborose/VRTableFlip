using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {

    public SteamVR_LoadLevel loadLevel;

    public string[] levels = new string[3] { "Level1", "Level2", "Level3" };
    public int currentLevel;
    public TableBehavior[] tablesInLevel;
    public flableBehavior[] flablesInLevel;

    public Text scoreText;
    public int scoreValue = 0;


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void ResetLevel()
    {
        // moves tables back
        // puts score to 0

       for (int i = 0; i < tablesInLevel.Length; i++)
        {
            tablesInLevel[i].ResetTable();
            scoreValue = 0;
            scoreText.text = scoreValue.ToString();
        }

    }

    public void IncrementScore(int scoreAmount)
    {
        scoreValue += scoreAmount;
        scoreText.text = scoreValue.ToString();
        Debug.Log("I have gained" + scoreAmount + "score");
    }

    [ContextMenu("GoToNextLevel")]
    public void GoToNextLevel()
    {
        if(currentLevel+1 <= levels.Length)
        {
            SteamVR_LoadLevel.Begin(levels[currentLevel + 1]);
        }


    }


}
