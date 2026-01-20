using System.Collections.Generic;
using UnityEngine;

public class EventDirector : MonoBehaviour
{
    
    //External
    public TMPro.TextMeshProUGUI currentObjective;
    public GameObject disappearObjective;
    public GameObject journalUI;
    public TMPro.TextMeshProUGUI journalTaskList;
    
    //InternalResources
    public List<string> objective;
    
    //InternalBooleans
    private bool isJournal = false;


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
    }

    public void Mission1Done()
    {
        currentObjective.text = "";
        currentObjective.text = objective[1];
        currentObjective.text = currentObjective.text + "\n" + objective[2];
        currentObjective.text = currentObjective.text + "\n" + objective[3];
        journalTaskList.text = journalTaskList.text +  "\n" + currentObjective.text;
    }
    

}
