using UnityEngine;

[CreateAssetMenu(fileName = "AtaqueGiratorioAction", menuName = "Scriptable Objects/AtaqueGiratorioAction")]
public class AtaqueGiratorioAction : UtilityAction
{
    [Header("Distance")]
    public float minDistance = 8f;
    public float maxDistance = 10f;

    [Header("Optional Curve")]
    public AnimationCurve scoreCurve = AnimationCurve.Linear(0, 0, 1, 1);

    public override float Score(EnemyContext context)
    {
        float distance = Vector3.Distance(
            context.transform.position,
            context.player.position
        );

        // Normaliza de 0 a 1
        float normalized = Mathf.InverseLerp(
            minDistance,
            maxDistance,
            distance
        );

        // Aplica curva
        float curved = scoreCurve.Evaluate(normalized);
        //Debug.Log("curved: " + curved);

        // Peso final da utility
        return curved * weight;

    }

    public override void Execute(EnemyContext context)
    {
        //Debug.Log("Executa o Ataque Giratorio");
        context.bossController.StartSpinningAttack();
    }
}
