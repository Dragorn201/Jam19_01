using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    //Resources
    public float Scoring;
    public float Money;
    private Vector3 Score;
    private float BestScore = 0f;
    
    public LaunchBrick launchBrick;
    
    //TMP
    public TMPro.TextMeshProUGUI ScoreText;
    public TMPro.TextMeshProUGUI BestScoreText;
    public TMPro.TextMeshProUGUI MoneyText;

    //UI
    public GameObject RestartUI;
    public GameObject UpgradeUI;
    public GameObject MainMenuUI;
    public GameObject LevelSelectionUI;
    public GameObject GameCanvaUI;
    public GameObject UILvl1;
    

    //Button
    public Button Upgrade1;
    [SerializeField] public float requirement1;
    public Button Upgrade2;
    [SerializeField] public float requirement2;
    public Button Upgrade3;
    [SerializeField] public float requirement3;

    public GameObject PlayerInteractable;



    void Start()
    {
        audioManager.Instance.PlayMusicClip(0);
    }
    
    private void Update()
    {
        
        
        Score = launchBrick.endPos - launchBrick.startPos; 
        Scoring = Score.x; 
        Scoring = Mathf.Floor(Scoring);
        
        ScoreText.text = Scoring.ToString();

        if (Scoring > 800)
        {
            SceneManager.LoadScene("Transtition");
        }


        // Upgrade 1 Button
        if (Money < requirement1)
        {
            Upgrade1.interactable = false;
        }
        else
        {
            Upgrade1.interactable = true;
        }
        
        //upgrade 2 Button
        if (Money < requirement2)
        {
            Upgrade2.interactable = false;
        }
        else
        {
            Upgrade2.interactable = true;
        }       
        
        //upgrade 3 button
        if (Money < requirement3)
        {
            Upgrade3.interactable = false;
        }
        else
        {
            Upgrade3.interactable = true;
        }           
    }


    public void RestartGame()
    {
        // Check if replace BestScore
        if (Score.x > BestScore)
        {
            BestScoreText.text = ScoreText.text; 
            BestScore = Score.x;
        }
        
        //Assign Money
        Money += Mathf.Floor(Scoring / 10f);
        MoneyText.text = Money.ToString();
        
        // Restart Brick Position and rotation
        launchBrick.transform.position = launchBrick.startPos;
        launchBrick.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        launchBrick.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
        launchBrick.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        launchBrick.GetComponent<Rigidbody>().useGravity = false;
        launchBrick.brickFlying = false;
        
        // Manipulate UI
        RestartUI.SetActive(false);
        UpgradeUI.SetActive(true);
        
    }

    
    /// UI Related ///
    
    public void goToLevelSelection()
    {
        MainMenuUI.SetActive(false);
        LevelSelectionUI.SetActive(true);
    }

    public void displayStartGamePanel()
    {
        UILvl1.SetActive(true);
    }
    
    public void StartGame()
    {
        LevelSelectionUI.SetActive(false);
        UILvl1.SetActive(false);
        GameCanvaUI.SetActive(true);
        PlayerInteractable.SetActive(true);
    }

    public void UIsound()
    {
        audioManager.Instance.PlaySfxClip(0);
    }
}
