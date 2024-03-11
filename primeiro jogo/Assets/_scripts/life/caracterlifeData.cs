using UnityEngine;

[CreateAssetMenu(fileName ="Char_", menuName ="ScriptableObject/Character")]
public class caracterlifeData : ScriptableObject
{
    [Tooltip("max character life")]
    public int fullLife;
    [Tooltip("recorvery time betwen damage")]
    public float timeBetwenDamage;
    [Tooltip("make character invulnerable during an amount of time in the timebetwendamage atribute")]
    public bool invulnerableOnDamage = true;
}
