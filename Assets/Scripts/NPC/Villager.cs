using UnityEngine;

public class Villager : Npc
{
    private bool isGaveBread;

    // сделать более гибким
    public override void ChangeInkVariableInUnity(string nameVariable, bool value)
    {
        if (nameVariable == nameof(isGaveBread))
            isGaveBread = value;
    }
    protected override void SetInkVariable()
    {
        _story.variablesState[nameof(isGaveBread)] = isGaveBread;
    }
}
