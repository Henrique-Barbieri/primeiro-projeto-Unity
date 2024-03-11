using UnityEngine;

[CreateAssetMenu(fileName ="Item_", menuName ="ScriptableObject/collectableintemData")]
public class collectableintemData : ScriptableObject
{
    public Sprite sprite;
    public collectableitemType type;
}

public enum collectableItemType{
    Cannon,
    Health,
    survivor
}