using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    
    //External
    public SC_FPSController fpController;
    public GameObject Character;
    public DialogueSysteme dialogueSystem;
    public DialogueSysteme optionnalDialogueSystem;
    public bool dispute = false;
    public TimelineDirector timelineDirector;
    public MainGameObjectCamera mainCamera;
    
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log(other.gameObject.name);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        
        fpController.walkingSpeed = 0f;
        audioManager.Instance.PlaySfxClip(3);
        dialogueSystem.dialogues[0].SetActive(true);
        dialogueSystem.Canva.SetActive(true);

        mainCamera.focusTarget = dialogueSystem.Canva.transform;
        

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
