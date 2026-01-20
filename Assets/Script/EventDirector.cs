using System.Collections.Generic;
using UnityEngine;

public class EventDirector : MonoBehaviour
{
    
    //External
    public TMPro.TextMeshProUGUI currentObjective;
    public GameObject disappearObjective;
    public GameObject journalUI;
    public TMPro.TextMeshProUGUI journalTaskList;
    
    public GameObject SpeakZoneClaudette;
    public GameObject SpeakZoneBernouille;
    public GameObject SpeakZoneTartare;
    public GameObject SpeakZoneMayor;
    
    public GameObject Berangere;
    public GameObject Michel;
    public GameObject Jenna;
    public GameObject Krapot;
    
    
    //InternalResources
    public List<string> objective;
    
    //InternalBooleans
    private bool isJournal = false;
    private bool Claudette = false;
    private bool Bernouille = false;
    private bool Tartare = false;
    private bool Mayor = false;
    [SerializeField] public bool Mission2 = false;
    

    void Start()
    {
        currentObjective.text = objective[0];
        journalTaskList.text = currentObjective.text;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isJournal)
            {
                journalUI.SetActive(true);
                isJournal = false;
                disappearObjective.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                journalUI.SetActive(false);
                isJournal = true;
                disappearObjective.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }


        if (Claudette && Bernouille && Tartare && Mayor)
        {
            Mission2 = true;
        }
        
        
    }

    public void StartMissions()
    {
        SpeakZoneClaudette.SetActive(true);
        SpeakZoneBernouille.SetActive(true);
        SpeakZoneTartare.SetActive(true);
        SpeakZoneMayor.SetActive(true);
    }
    
    
    
    public void Mission1Done()
    {
        currentObjective.text = "";
        currentObjective.text = objective[1];
        currentObjective.text = currentObjective.text + "\n" + objective[2];
        currentObjective.text = currentObjective.text + "\n" + objective[3];
        journalTaskList.text = journalTaskList.text +  "\n" + currentObjective.text;
    }
    
    public void SpeakToClaudette()
    { Claudette = true; }
    public void SpeakToBernouille()
    { Bernouille = true; }
    public void SpeakToTartare()
    { Tartare = true; }
    public void SpeakToMayor()
    { Mayor = true; }


    public void JennaBerangereMichelSpawn()
    {
        Jenna.SetActive(true);
        Michel.SetActive(true);
        Berangere.SetActive(true);
        Krapot.SetActive(true);
    }

}
