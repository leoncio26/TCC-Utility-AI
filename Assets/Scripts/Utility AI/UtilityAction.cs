using UnityEngine;

[CreateAssetMenu(fileName = "UtilityAction", menuName = "Scriptable Objects/UtilityAction")]
public abstract class UtilityAction : ScriptableObject
{
    [Range(0f, 10f)] public float weight = 1f;

    public abstract float Score(EnemyContext context);
    public abstract void Execute(EnemyContext context);
}
