using UnityEngine;

[CreateAssetMenu(fileName = "MeleeAttackAction", menuName = "Scriptable Objects/MeleeAttackAction")]
public class MeleeAttackAction : UtilityAction
{
    public override float Score(EnemyContext context)
    {
        //float dist = Vector2.Distance(context.transform.position, context.player.position);
        //var score = dist < context.attackRange ? 1f : 0f; ;
        //Debug.Log("MeleeAttackAction Score:" + score);
        //return score;

        float dist = Mathf.Abs(
            context.transform.position.x - context.player.position.x
        );

        if (dist > context.combat.attackRange)
            return 0f;

        if (!context.combat.CanAttack())
            return 0f;

        return 1f;
    }

    public override void Execute(EnemyContext context)
    {
        //Debug.Log("Ataque Melee!");
        //context.rb.linearVelocity = Vector2.zero;

        // parar movimento
        context.movement.Move(0);

        // virar para o jogador
        float dir = Mathf.Sign(context.player.position.x - context.transform.position.x);

        //context.movement.FaceDirection(dir);

        // animação
        context.animatorController.PlayAttackMelee();

        // ataque lógico
        context.combat.Attack(
            context.transform,
            context.player
        );
    }
}
