using System.Collections.Generic;
using UnityEngine;

public class EventDirector : MonoBehaviour
{
    
    //External
    public TMPro.TextMeshProUGUI currentObjective;
    public GameObject disappearObjective;
    public GameObject journalUI;
    public TMPro.TextMeshProUGUI journalTaskList;
    public GameObject ArbreUI;
    
    
    public GameObject SpeakZoneClaudette;
    public GameObject SpeakZoneBernouille;
    public GameObject SpeakZoneTartare;
    public GameObject SpeakZoneMayor;
    
    
    public GameObject Berangere;
    public GameObject Michel;
    public GameObject Jenna;
    public GameObject Krapot;
    
    public SC_FPSController controller;
    
    
    //InternalResources
    public List<string> objective;
    
    //InternalBooleans
    private bool isJournal = true;
    private bool isArbre = true;
    private bool Claudette = false;
    private bool Bernouille = false;
    private bool Tartare = false;
    private bool Mayor = false;

    private bool BerangereBool = false;
    private bool MichelBool = false;
    private bool JennaBool = false;
    private bool KrapotBool = false;
    
    [SerializeField] public bool Mission2 = false;
    private bool Mission1done = false;
    [SerializeField] public bool Mission5 = false; 
    private bool Mission5done = false;

    void Start()
    {
        currentObjective.text = objective[0];
        journalTaskList.text = currentObjective.text;
        audioManager.Instance.PlayMusicClip(1);
        audioManager.Instance.PlayMusicClip(2);

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
                controller.walkingSpeed = 0f;
                audioManager.Instance.PlaySfxClip(4);
            }
            else
            {
                journalUI.SetActive(false);
                isJournal = true;
                disappearObjective.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                controller.walkingSpeed = 7.5f;
                audioManager.Instance.PlaySfxClip(4);
            }
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (isArbre)
            {
                ArbreUI.SetActive(true);
                isArbre = false;
                disappearObjective.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Debug.Log("Cursor");
                controller.walkingSpeed = 0f;
                audioManager.Instance.PlaySfxClip(4);
            }
            else
            {
                ArbreUI.SetActive(false);
                isArbre = true;
                disappearObjective.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                controller.walkingSpeed = 7.5f;
                audioManager.Instance.PlaySfxClip(4);
            }
        }
        


        if (Claudette && Bernouille && Tartare && Mayor && Mission1done== false)
        {
            Mission2 = true;
            Mission2Done();
            Mission1done = true;
        }

        if (BerangereBool && MichelBool && JennaBool && KrapotBool && Mission5done == false)
        {
            Mission5 = true;
            currentObjective.text = objective[9];
            Mission5done = true;
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

    public void Mission2Done()
    {
        currentObjective.text = "";
        currentObjective.text = objective[4];
        journalTaskList.text = journalTaskList.text +  "\n" + currentObjective.text;
    }

    public void Mission3Done()
    {
        currentObjective.text = "";
        currentObjective.text = objective[5];
        currentObjective.text = currentObjective.text + "\n" + objective[6];
        currentObjective.text = currentObjective.text + "\n" + objective[7];
        currentObjective.text = currentObjective.text + "\n" + objective[8];
        journalTaskList.text = "";
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

    public void SpeakToBerangere()
    { BerangereBool = true; }
    public void SpeakToMichel()
    { MichelBool = true; }
    public void SpeakToJenna()
    { JennaBool = true; }
    public void SpeakToKrapot()
    { KrapotBool = true; }
    
    

    public void JennaBerangereMichelSpawn()
    {
        Jenna.SetActive(true);
        Michel.SetActive(true);
        Berangere.SetActive(true);
        Krapot.SetActive(true);
    }

}
