using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "DefesaEscudoAction", menuName = "Scriptable Objects/DefesaEscudoAction")]
public class DefesaEscudoAction : UtilityAction
{
    [Header("Distance")]
    public float meleeDangerDistance = 2.5f;

    [Header("Scores")]
    public float meleeScore = 0.7f;

    public override float Score(EnemyContext context)
    {
        //if (context.isBlocking) return 0;
        float score = 0f;

        if (context.incomingProjectileDetected) return 1;

        float distance =
            Vector2.Distance(
                context.transform.position,
                context.player.position
            );

        // Jogador perto com espada
        if (distance <= meleeDangerDistance &&
            context.playerIsAttackingMelee)
        {
            score += meleeScore;
            Debug.Log("Ataque melee do jogador");
        }

        return Mathf.Clamp01(score);
    }

    public override void Execute(EnemyContext context)
    {
        //if (context.isBlocking)
        //    return;
        Debug.Log("Usa o Escudo");
        context.StartCoroutine(ShieldRoutine(context));
    }

    public IEnumerator ShieldRoutine(EnemyContext context)
    {
        context.executing = true;

        yield return new WaitForSeconds(context.projectilReactionTime);
        
        context.isBlocking = true;

        context.animator.SetBool("ShieldDefense", true);

        float timer = 0f;
        float maxBlockTime = 1.2f;

        while (timer < maxBlockTime)
        {
            float distance = Vector2.Distance(context.player.position, context.transform.position);
            Debug.Log("Distance" + distance);

            if (context.incomingProjectileDetected || distance < meleeDangerDistance)
            {
                timer = 0f;
            }

            timer += Time.deltaTime;

            yield return null;
        }

        context.animator.SetBool("ShieldDefense", false);

        context.isBlocking = false;
        context.executing = false;
        context.playerIsAttackingMelee = false;
    }
}
