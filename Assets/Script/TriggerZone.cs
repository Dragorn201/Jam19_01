using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    
    //External
    public SC_FPSController fpController;
    public DialogueSysteme dialogueSystem;
    public DialogueSysteme optionnalDialogueSystem;
    public bool dispute = false;
    public TimelineDirector timelineDirector;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        fpController.walkingSpeed = 0f;
        audioManager.Instance.PlaySfxClip(3);
        dialogueSystem.dialogues[0].SetActive(true);
        dialogueSystem.Canva.SetActive(true);

        if (optionnalDialogueSystem != null)
        {
            //optionnalDialogueSystem.dialogues[0].SetActive(true);
            optionnalDialogueSystem.Canva.SetActive(true);
            if (dispute)
            {
                audioManager.Instance.PlaySfxClip(6);
            }
            
        }
        
        
    }
}
