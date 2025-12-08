using UnityEngine;

[CreateAssetMenu(fileName = "New Debuff", menuName = "Gameplay/Debuff")]
public class Debuff : ScriptableObject
{
    new public string name = "New Debuff";
    public Sprite icon;
    public float duration;
}
