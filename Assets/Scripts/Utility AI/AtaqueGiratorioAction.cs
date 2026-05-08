using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "AtaqueGiratorioAction", menuName = "Scriptable Objects/AtaqueGiratorioAction")]
public class AtaqueGiratorioAction : UtilityAction
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
        //Debug.Log("curved: " + curved);

        // Peso final da utility
        return curved * weight;

    }

    public override void Execute(EnemyContext context)
    {
        //Debug.Log("Executa o Ataque Giratorio");
        context.StartCoroutine(SpinningAttackRoutine(context));
    }

    private IEnumerator SpinningAttackRoutine(EnemyContext context)
    {
        Debug.Log("Executa o Ataque Giratorio refatorado");
        var transform = context.transform;
        var animator = context.animator;

        context.executing = true;

        animator.SetTrigger("SpinAttack");

        float directionX =
            Mathf.Sign(context.player.position.x - transform.position.x);

        Vector2 attackDirection = new Vector2(directionX, 0f);

        // WINDUP
        yield return new WaitForSeconds(windupTime);


        float timer = 0f;

        while (true)
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
                break;
            }

            yield return null;
        }

        Debug.Log("Finalizou giro");

        animator.SetBool("SpinAttack", false);

        transform.localRotation = Quaternion.identity;
        
        yield return new WaitForSeconds(recoveryTime);
        
        context.executing = false;

    }
}
