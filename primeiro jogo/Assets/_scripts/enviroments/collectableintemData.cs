using UnityEngine;

[CreateAssetMenu(fileName ="Item_", menuName ="ScriptableObject/collectableitem")]
public class collectableitemData : ScriptableObject
{
    public Sprite sprite;
    public collectableitemType type;
}

public enum collectableitemType{
    Cannon,
    Health,
    survivor
}