using System;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class DialogueSysteme : MonoBehaviour
{
    
    //UI
    public GameObject Canva;
    public GameObject ReactivatePlayerButton;
    public List<GameObject> dialogues;
    
    //etc
    
    //External
    public SC_FPSController fpController;
    public EventDirector eventDirector;
    public GameObject NextCharacter;
    public DialogueSysteme otherCharacter;
    
    //Internal
    private int numberOfDialogues= 0;
    private int dialogueCounter = 0;
    public int whereEvent;
    public int whereEventNextCharacter;
    public bool NextCharacterExist;
    public GameObject self;



    void Start()
    {
        Canva.SetActive(false);
        ReactivatePlayerButton.SetActive(false);
        numberOfDialogues = dialogues.Count;
        Debug.Log(numberOfDialogues);

        for (int i = 0; i < numberOfDialogues; i++)
        {
            dialogues[i].SetActive(false);
        }
    }
    
    
    
    public void nextDialogue()
    {
        if (dialogueCounter+1 < numberOfDialogues)
        {
            if (dialogueCounter+1 == whereEvent)
            {
                Debug.Log("aled");
                dialogues[dialogueCounter].SetActive(false);
                //ReactivatePlayerButton.SetActive(true);

                if (NextCharacterExist)
                {
                    NextCharacter.SetActive(true);
                    self.SetActive(false);
                }
                else if (otherCharacter != null)
                {
                    otherCharacter.whereEvent = whereEventNextCharacter;
                    dialogues[dialogueCounter].SetActive(false);
                    ReactivatePlayerButton.SetActive(true);
                }
                else
                {
                    dialogues[dialogueCounter].SetActive(false);
                    ReactivatePlayerButton.SetActive(true);
                }

                
            }
            else
            {
                dialogueCounter++;
                Debug.Log(dialogueCounter);
                dialogues[dialogueCounter].SetActive(true);
                dialogues[dialogueCounter-1].SetActive(false);               
            }

            
        }
        else
        {
            dialogues[dialogueCounter].SetActive(false);
            ReactivatePlayerButton.SetActive(true);
        }

    }
    
    
    
    
    
    public void ReactivatePlayer()
    {
        ReactivatePlayerButton.SetActive(false);
        Canva.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        dialogueCounter = 0;
        
        fpController.walkingSpeed = 7.5f;
    }

}
