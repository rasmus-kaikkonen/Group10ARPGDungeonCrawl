using UnityEngine;

[CreateAssetMenu(fileName = "Buff", menuName = "Gameplay/Buff")]
public class Buff : ScriptableObject
{
    new public string name = "New Buff";
    public Sprite icon;
    public float duration;
}
