using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "LeapAttackAction", menuName = "Scriptable Objects/LeapAttackAction")]
public class LeapAttackAction : UtilityAction
{
    public float minDistance = 3f;
    public float maxDistance = 8f;
    public float idealDistance = 5f;

    public override float Score(EnemyContext context)
    {
        if (context.isLeaping)
            return 0f;

        if (!context.combat.CanAttack())
            return 0f;

        float dist = Mathf.Abs(
            context.transform.position.x - context.player.position.x
        );

        // fora da zona útil
        //if (dist < minDistance || dist > maxDistance)
        //    return 0f;

        //Debug.Log("Dentro da area de ataque: " + context.player.position.x);

        // quanto mais perto do ideal, maior o score
        //float linear = 1f - Mathf.Abs(dist - idealDistance) / (maxDistance - minDistance);
        //float score = linear * linear;//Curva quadratica

        //float timeSinceLastLeap = Time.time - context.lastLeapTime;

        //float cooldown = 3f;

        //score *= Mathf.Clamp01(timeSinceLastLeap / cooldown);

        float t = Mathf.InverseLerp(minDistance, maxDistance, dist);
        float score = 4f * t * (1f - t);

        return Mathf.Clamp01(score);
    }

    public override void Execute(EnemyContext context)
    {
        //context.bossController.Move(0);

        float dir = Mathf.Sign(
            context.player.position.x - context.transform.position.x
        );

        //Debug.Log("[Execute] Obtendo posição X do Jogador: " + context.player.position.x);
        //context.capangaController.FaceDirection(dir);

        //context.animator.PlayJumpAttack();

        context.StartCoroutine(DoLeap(context));

        context.lastLeapTime = Time.time;
    }

    private IEnumerator DoLeap(EnemyContext context)
    {
        context.isLeaping = true;

        yield return null; // espera 1 frame

        Vector2 start = context.transform.position;
        Vector2 end = context.player.position;

        //Debug.Log("Obtendo posição X do Jogador: " + context.player.position.x);

        //DEBUG AQUI
        Debug.DrawLine(start, context.player.position, Color.red, 1f);   // onde o player estava
        Debug.DrawLine(start, end, Color.green, 1f);       // onde o inimigo vai pular

        float duration = 0.6f;
        float height = 2f;

        float time = 0;

        while (time < duration)
        {
            float t = time / duration;

            Vector2 pos = Vector2.Lerp(start, end, t);
            pos.y += Mathf.Sin(t * Mathf.PI) * height;

            context.transform.position = pos;

            time += Time.deltaTime;
            yield return null;
        }

        context.transform.position = end;

        context.combat.Attack(context.transform, context.player);

        //context.bossController.Move(0);
        context.isLeaping = false;
    }
}
