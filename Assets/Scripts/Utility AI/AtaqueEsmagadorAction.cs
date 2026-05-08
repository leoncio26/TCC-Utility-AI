using System.Collections;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

[CreateAssetMenu(fileName = "AtaqueEsmagadorAction", menuName = "Scriptable Objects/AtaqueEsmagadorAction")]
public class AtaqueEsmagadorAction : UtilityAction
{
    [Header("Distance")]
    public float minDistance = 0f;
    public float maxDistance = 2f;

    [Header("Jump")]
    public float jumpHeight = 4f;

    public float riseDuration = 0.6f;
    public float fallDuration = 0.2f;

    public override float Score(EnemyContext context)
    {
        var distance = Vector3.Distance(context.transform.position, context.player.position);
        Debug.Log("distance: " + distance);

        if (distance > maxDistance) return 0;

        // Normaliza de 0 a 1
        float normalized = Mathf.InverseLerp(
            minDistance,
            maxDistance,
            distance
        );

        Debug.Log("normalized: " + normalized);

        return 1f - normalized;
    }

    public override void Execute(EnemyContext context)
    {
        context.executing = true;
        context.StartCoroutine(JumpRoutine(context));
    }

    private IEnumerator JumpRoutine(EnemyContext context)
    {
        Transform boss = context.transform;

        Vector3 startPos = boss.position;

        // pega a posição do jogador no começo do ataque
        // isso evita o boss ficar "teleguiado"
        Vector3 targetPos = context.player.position;

        // opcional:
        // mantém o mesmo Y do boss
        targetPos.y = startPos.y;

        float totalDuration = riseDuration + fallDuration;

        float t = 0f;

        while (t < totalDuration)
        {
            t += Time.deltaTime;

            float normalizedTime = t / totalDuration;

            // ----------------------------
            // MOVIMENTO HORIZONTAL
            // ----------------------------

            Vector3 horizontalPos = Vector3.Lerp(
                startPos,
                targetPos,
                normalizedTime
            );

            // ----------------------------
            // MOVIMENTO VERTICAL
            // ----------------------------

            float yOffset;

            if (t <= riseDuration)
            {
                // SUBIDA

                float riseT = t / riseDuration;

                // suave
                riseT = Mathf.SmoothStep(0f, 1f, riseT);

                yOffset = Mathf.Lerp(
                    0f,
                    jumpHeight,
                    riseT
                );
            }
            else
            {
                // DESCIDA

                float fallT =
                    (t - riseDuration) / fallDuration;

                // queda acelerada
                fallT = fallT * fallT;

                yOffset = Mathf.Lerp(
                    jumpHeight,
                    0f,
                    fallT
                );
            }

            boss.position = horizontalPos + Vector3.up * yOffset;

            yield return null;
        }

        boss.position = targetPos;

        yield return new WaitForSeconds(3f);

        context.executing = false;

        // impacto no chão
        Debug.Log("SMASH!");
    }
}
