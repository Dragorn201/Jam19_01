using System;
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

    public GameObject KrapotStart;
    public GameObject MichelStart;
    public GameObject Krapot2;
    public GameObject Michel2;
    public GameObject Michel2dialogue;

    public DialogueSysteme Michel2dialogueSystem;
    public DialogueSysteme Michel3dialogueSystem;
    public DialogueSysteme Krapot2dialogueSystem;

    public GameObject disputeDeclencheur;


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
        Krapot2.SetActive(true);
        Michel2dialogue.SetActive(true);
        Michel2.SetActive(true);
    }

    public void KrapotSpeak()
    {
        Krapot2dialogueSystem.Canva.SetActive(true);
        Krapot2dialogueSystem.dialogues[0].SetActive(true);
        Michel2dialogueSystem.Canva.SetActive(false);
    }

    public void MichelSpeak()
    {
        Michel3dialogueSystem.Canva.SetActive(true);
        Michel3dialogueSystem.dialogues[0].SetActive(true);
        Krapot2dialogueSystem.Canva.SetActive(false);
    }

    public void restartDispute()
    {
        disputeDeclencheur.SetActive(false);
    }


    
    
}
