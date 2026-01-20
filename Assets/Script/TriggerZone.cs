using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    
    //External
    public SC_FPSController fpController;
    public DialogueSysteme dialogueSystem;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        fpController.walkingSpeed = 0f;
        
        dialogueSystem.dialogues[0].SetActive(true);
        dialogueSystem.Canva.SetActive(true);
    }
}
