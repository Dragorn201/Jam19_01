using UnityEngine;

public class eventModifier : MonoBehaviour
{

    //External
    public DialogueSysteme toModify;
    
    void OnTriggerEnter(Collider collider)
    {
        toModify.whereEvent = 2;
    }
    
}
