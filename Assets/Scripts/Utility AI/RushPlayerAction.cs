using UnityEngine;

[CreateAssetMenu(fileName = "RushPlayerAction", menuName = "Scriptable Objects/RushPlayerAction")]
public class RushPlayerAction : UtilityAction
{
    public override float Score(EnemyContext context)
    {
        // Sempre tem algum score, capanga burro corre pra cima
        float dist = Mathf.Abs(
            context.transform.position.x - context.player.position.x
        );

        if (dist <= context.combat.attackRange)
            return 0f;

        return 0.6f;
    }

    public override void Execute(EnemyContext context)
    {
        Debug.Log("RushPlayerAction");
        //float directionX = Mathf.Sign(context.player.position.x - context.transform.position.x);

        //// Mantém velocidade vertical atual (gravidade)
        //Vector2 newVelocity = new Vector2(directionX * context.moveSpeed, context.rb.linearVelocity.y);

        //context.rb.linearVelocity = newVelocity;

        float dir = Mathf.Sign(
            context.player.position.x - context.transform.position.x
        );

        context.movement.Move(dir);
        context.movement.FaceDirection(dir);
    }
}
