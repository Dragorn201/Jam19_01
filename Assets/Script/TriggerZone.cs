using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    
    //External
    public SC_FPSController fpController;
    public DialogueSysteme dialogueSystem;
    public DialogueSysteme optionnalDialogueSystem;
    public DialogueSysteme optionnalDialogueSystem2;
    public TimelineDirector timelineDirector;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        fpController.walkingSpeed = 0f;
        
        dialogueSystem.dialogues[0].SetActive(true);
        dialogueSystem.Canva.SetActive(true);

        if (optionnalDialogueSystem != null)
        {
            //optionnalDialogueSystem.dialogues[0].SetActive(true);
            optionnalDialogueSystem.Canva.SetActive(true);
            optionnalDialogueSystem2.Canva.SetActive(true);
            
        }
        
        
    }
}
