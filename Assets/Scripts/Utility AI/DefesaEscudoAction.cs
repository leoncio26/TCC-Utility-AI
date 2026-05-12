using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "DefesaEscudoAction", menuName = "Scriptable Objects/DefesaEscudoAction")]
public class DefesaEscudoAction : UtilityAction
{
    public override float Score(EnemyContext context)
    {
        if (context.isBlocking) return 0;

        if (context.incomingProjectileDetected) return 1;

        return 0;
    }

    public override void Execute(EnemyContext context)
    {
        if (context.isBlocking)
            return;

        context.StartCoroutine(ShieldRoutine(context));
    }

    public IEnumerator ShieldRoutine(EnemyContext context)
    {
        context.isBlocking = true;

        yield return new WaitForSeconds(.2f);

        context.animator.SetBool("ShieldDefense", true);

        float timer = 0f;
        float maxBlockTime = 1.2f;

        while (timer < maxBlockTime)
        {
            if (context.incomingProjectileDetected)
            {
                timer = 0f;
            }

            timer += Time.deltaTime;

            yield return null;
        }

        context.animator.SetBool("ShieldDefense", false);

        context.isBlocking = false;

    }
}
