using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class ItemInfo : ScriptableObject
{
    public string id;
    public new string name;
    public string description;
    public Sprite icon;

}
