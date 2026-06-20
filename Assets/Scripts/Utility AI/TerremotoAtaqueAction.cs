
using UnityEngine;

[CreateAssetMenu(fileName = "TerremotoAtaqueAction", menuName = "Scriptable Objects/TerremotoAtaqueAction")]
public class TerremotoAtaqueAction : UtilityAction
{
    [Header("Distance")]
    public float minDistance = 8f;
    public float maxDistance = 10f;

    [Header("Optional Curve")]
    public AnimationCurve scoreCurve = AnimationCurve.Linear(0, 0, 1, 1);

    public override float Score(EnemyContext context)
    {
        var dist = Vector3.Distance(context.transform.position, context.player.position);

        var normalize = Mathf.InverseLerp(minDistance, maxDistance, dist);

        float curve = scoreCurve.Evaluate(normalize);

        Debug.Log("Terremoto Score: " + curve * (1 - context.bossLifeNormalized));

        return curve * (1 - context.bossLifeNormalized);
    }

    public override void Execute(EnemyContext context)
    {
        context.isTerremotoAtaque = true;
        context.animatorController.Play("Martelada");
    }
}
