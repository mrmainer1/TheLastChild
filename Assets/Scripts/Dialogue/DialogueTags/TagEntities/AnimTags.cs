using UnityEngine;
public class AnimTags : MonoBehaviour, ITag
{
    [SerializeField] private Animator _player;
    public void Calling(string value)
    {
        Debug.Log(value);
        _player.SetTrigger(value);
    }
}
