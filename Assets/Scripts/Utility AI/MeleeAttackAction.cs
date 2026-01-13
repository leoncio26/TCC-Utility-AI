using UnityEngine;

[CreateAssetMenu(fileName = "MeleeAttackAction", menuName = "Scriptable Objects/MeleeAttackAction")]
public class MeleeAttackAction : UtilityAction
{
    public override float Score(EnemyContext context)
    {
        float dist = Vector2.Distance(context.transform.position, context.player.position);
        var score = dist < context.attackRange ? 1f : 0f; ;
        Debug.Log("MeleeAttackAction Score:" + score);
        return score;
    }

    public override void Execute(EnemyContext context)
    {
        // Aqui você põe sua animação de ataque
        Debug.Log("Capanga atacou!");
        context.rb.linearVelocity = Vector2.zero;
    }
}
