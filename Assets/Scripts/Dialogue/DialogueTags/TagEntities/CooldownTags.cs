using UnityEngine;

public class CooldownTags : MonoBehaviour, ITag
{
    public void Calling(string value)
    {
        float number = float.Parse(value);

        DialogueWindow dialogueWindow = GetComponent<DialogueWindow>();
        dialogueWindow.SetCooldown(number);
    }
}
