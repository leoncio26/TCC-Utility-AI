using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "AtaqueGiratorioMultiploAction", menuName = "Scriptable Objects/AtaqueGiratorioMultiploAction")]
public class AtaqueGiratorioMultiplo : UtilityAction
{
    [Header("Distance")]
    public float minDistance = 8f;
    public float maxDistance = 10f;

    [Header("Optional Curve")]
    public AnimationCurve scoreCurve = AnimationCurve.Linear(0, 0, 1, 1);

    [Header("Spin Attack")]
    public float spinDuration = 1.5f;
    public float spinSpeed = 12f;
    public float rotationSpeed = 1080f;
    public float windupTime = 0.4f;
    public float recoveryTime = 3f;

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

        // Peso final da utility
        //Debug.Log("Ataque Giratorio Multiplo: " + curved * context.bossLifeNormalized);
        return curved * context.bossLifeNormalized;
    }

    public override void Execute(EnemyContext context)
    {
        Debug.Log("Executa o Ataque Giratorio Multiplo");

        context.executing = true;

        context.StartCoroutine(SpinningAttackRoutine(context));
    }

    private IEnumerator SpinningAttackRoutine(EnemyContext context)
    {
        var transform = context.transform;
        var animator = context.animator;
        int numAttacks = 3;

        animator.SetBool("SpinAttack", true);
        context.isAttackNoDamage = true;

        float directionX =
            Mathf.Sign(context.player.position.x - transform.position.x);

        Vector2 attackDirection = new Vector2(directionX, 0f);

        // WINDUP
        yield return new WaitForSeconds(windupTime);


        float timer = 0f;

        while (numAttacks > 0)
        {
            timer += Time.deltaTime;

            // gira no eixo Z (2D)
            transform.Rotate(
                0f,
                0f,
                rotationSpeed * Time.deltaTime
            );

            // movimento
            transform.position +=
                (Vector3)(attackDirection * spinSpeed * Time.deltaTime);

            if (transform.position.x <= context.leftLimit.position.x ||
                transform.position.x >= context.rightLimit.position.x)
            {
                attackDirection *= -1;
                numAttacks--;
                //Debug.Log("NumGiro: " + numAttacks);
                yield return new WaitForSeconds(0.15f);
            }

            yield return null;
        }

        //Debug.Log("Finalizou giro multiplo");

        transform.localRotation = Quaternion.identity;

        context.executing = false;
        context.isAttackNoDamage = false;

        animator.SetBool("SpinAttack", false);

    }
}
