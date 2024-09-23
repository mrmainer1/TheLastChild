using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpeakerTags), typeof(CooldownTags), typeof(AudioTags))]
[RequireComponent(typeof(AnimTags), typeof(ItemTags), typeof(ChangeVariableTags))]
public class Tags : MonoBehaviour
{
    private readonly Dictionary<string, ITag> _map = new Dictionary<string, ITag>();
    private void Start()
    {
        _map.Add("speaker", GetComponent<SpeakerTags>());
        _map.Add("cooldown", GetComponent<CooldownTags>());
        _map.Add("anim", GetComponent<AnimTags>());
        _map.Add("item", GetComponent<ItemTags>());
        _map.Add("variableChange", GetComponent<ChangeVariableTags>());
        _map.Add("audio", GetComponent<AudioTags>());
    }
    public ITag GetValue(string key)
    {
        return _map.GetValueOrDefault(key);
    }
}

