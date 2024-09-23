using UnityEngine;

public class SpeakerTags : MonoBehaviour, ITag
{ 
    public void Calling(string value)
    {
        DialogueWindow dialogueWindow = GetComponent<DialogueWindow>();
        dialogueWindow.SetName(value);
    }
}
