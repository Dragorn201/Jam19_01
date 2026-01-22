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
    public Camera MainCamera;
    public Camera EndingCamera;
    public GameObject EndingCameraObject;
    public SC_FPSController controller;


    //Dispute
    public GameObject Mayor;
    public GameObject Claudette;
    
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
    public GameObject KrapotMort;
    public GameObject KrapottoKill;
    public GameObject MichelMort;
    public GameObject MicheltoKill;
    public GameObject VitoSpawn;
    public GameObject VitoDead;

    public GameObject johnatanStart;
    public GameObject johnatanFinal;


    void Start()
    {
        MainCamera = controller.playerCamera;
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
        Mayor.SetActive(false);
        Claudette.SetActive(false);
        KrapotStart.SetActive(false);
        MichelStart.SetActive(false);
        Krapot2Spawn.SetActive(true);
        Michel2dialogue.SetActive(true);
        Michel2.SetActive(true);
        
        JennaToDisappear.SetActive(false);
        BernouilleToDisappear.SetActive(false);
        EventDirector.currentObjective.text = EventDirector.objective[10];
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
        EventDirector.currentObjective.text = EventDirector.objective[11];
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
        EventDirector.currentObjective.text = EventDirector.objective[12];
        MicheltoKill.SetActive(false);
        MichelMort.SetActive(true);
        KrapotMort.SetActive(true);
        KrapottoKill.SetActive(false);
        VitoSpawn.SetActive(true);
    }

    public void VitoDie()
    {
        StartCoroutine(waitBlackScreen());
        VitoSpawn.SetActive(false);
        VitoDead.SetActive(true);
        johnatanStart.SetActive(false);
        johnatanFinal.SetActive(true);
        EventDirector.currentObjective.text = EventDirector.objective[13];
    }


    public void Conclusion()
    {
        MainCamera.enabled = false;
        EndingCameraObject.SetActive(true);
        EndingCamera.enabled = true;
    }
    
}
