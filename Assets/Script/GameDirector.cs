using System;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public float Scoring;
    public int Money;
    
    private Vector3 Score;
    public TMPro.TextMeshProUGUI ScoreText;


    public LaunchBrick launchBrick;
    

    private void Update()
    {
        
        
        Score = launchBrick.endPos - launchBrick.startPos; 
        Scoring = Score.x; 
        Scoring = Mathf.Floor(Scoring);
        
        ScoreText.text = Scoring.ToString();
    }

}
