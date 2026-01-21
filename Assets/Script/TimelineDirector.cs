using System;
using System.Collections;
using UnityEngine;

public class TimelineDirector : MonoBehaviour
{
    //Internal
    private bool Mission2Started = false;
    private bool Mission5Started = false;
    [SerializeField] public bool krapotcanSpeak =false;
    
    //External
    public GameObject MariaStart;
    public GameObject MariaMission2;
    public GameObject MariaMission3;
    public EventDirector EventDirector;
    public GameObject BlackScreen;

    //Dispute
    public GameObject KrapotStart;
    public GameObject MichelStart;
    public GameObject Michel2;
    public GameObject Michel3;
    public GameObject Michel2dialogue;
    public GameObject Krapot2Spawn;
    public GameObject JennaToDisappear;
    public GameObject BernouilleToDisappear;
    public DialogueSysteme Michel2dialogueSystem;
    public DialogueSysteme Michel3dialogueSystem;
    public DialogueSysteme Krapot2dialogueSystem;
    public GameObject disputeDeclencheur;
    
    //FinalAct
    public GameObject Maria3ToDisappear;
    public GameObject Maria4;
    public GameObject MariaDead;
    public GameObject MariaSpeakZone;
    public GameObject BerangereDie;
    public GameObject BerangereDead;


    void Start()
    {
    }

    IEnumerator waitBlackScreen()
    {
        BlackScreen.SetActive(true);
        yield return new WaitForSeconds(2f);
        BlackScreen.SetActive(false);
    }

    private void Update()
    {
        if (EventDirector.Mission2 && !Mission2Started)
        {
            MariaStart.SetActive(false);
            MariaMission2.SetActive(true);
            Mission2Started = true;
        }

        if (EventDirector.Mission5 && !Mission5Started)
        {
            MariaMission2.SetActive(false);
            MariaMission3.SetActive(true);
            Mission5Started = true;
        }
    }

    public void declencheDispute()
    {
        KrapotStart.SetActive(false);
        MichelStart.SetActive(false);
        Krapot2Spawn.SetActive(true);
        Michel2dialogue.SetActive(true);
        Michel2.SetActive(true);
        
        JennaToDisappear.SetActive(false);
        BernouilleToDisappear.SetActive(false);
    }

    public void KrapotSpeak()
    {
        Krapot2dialogueSystem.Canva.SetActive(true);
        Krapot2dialogueSystem.dialogues[0].SetActive(true);
        Michel2dialogueSystem.Canva.SetActive(false);
    }

    public void MichelSpeak()
    {
        Michel3.SetActive(true);
        Michel2.SetActive(false);
        Michel3dialogueSystem.Canva.SetActive(true);
        Michel3dialogueSystem.dialogues[0].SetActive(true);
        Krapot2dialogueSystem.Canva.SetActive(false);
    }

    public void restartDispute()
    {
        disputeDeclencheur.SetActive(false);
    }


    public void MariaDepression()
    {
        Maria3ToDisappear.SetActive(false);
        Maria4.SetActive(true);
        BerangereDie.SetActive(false);
        BerangereDead.SetActive(true);
    }

    public void MariaDie()
    {
        audioManager.Instance.PlaySfxClip(7);
        StartCoroutine(waitBlackScreen());
        Maria4.SetActive(false);
        MariaDead.SetActive(true);
        MariaSpeakZone.SetActive(false);
        
        
    }
    
    
}
