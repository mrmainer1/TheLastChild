using UnityEngine;
public class AudioTags : MonoBehaviour, ITag
{
    public void Calling(string value)
    {
        DialogueController dialogueController = GetComponent<DialogueController>();
        dialogueController.Collocutor.PlaySound(value);
    }
}
