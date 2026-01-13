using UnityEngine;

[CreateAssetMenu(fileName = "CircleAroundPlayerAction", menuName = "Scriptable Objects/CircleAroundPlayerAction")]
public class CircleAroundPlayerAction : UtilityAction
{
    [Tooltip("Distancia lateral alvo (unidades do mundo).")]
    public float desiredDistance = 2f;

    [Tooltip("Velocidade multiplicador ao flanquear (0-1)")]
    public float speedMultiplier = 0.7f;

    [Tooltip("Tolerancia para considerar 'chegou' a possivel alvo (em unidades).")]
    public float arrivalTolerance = 0.12f;

    // Se quiser que, ao chegar, ele pare e permane�a por X segundos antes de recalcular:
    public float holdTimeOnArrival = 0f;

    // Estado interno (opcional): tempo que est� segurando quando chegou
    private float holdTimer = 0f;

    public override float Score(EnemyContext context)
    {
        float dist = Mathf.Abs(context.transform.position.x - context.player.position.x);
        float diff = Mathf.Abs(dist - desiredDistance);
        var score = Mathf.Clamp01(1f - diff / desiredDistance);
        Debug.Log("CircleAroundPlayerAction Score:" + score);
        return score;
    }

    public override void Execute(EnemyContext context)
    {
        Debug.Log("CircleAroundPlayerAction");
        // Se o designer colocou um holdTime, respeitamos ele (previne troca instant�nea)
        if (holdTimeOnArrival > 0f && holdTimer > 0f)
        {
            holdTimer -= Time.deltaTime;
            // Mant�m parada horizontalmente (mas preserva gravidade)
            context.rb.linearVelocity = new Vector2(0f, context.rb.linearVelocity.y);
            return;
        }

        float playerX = context.player.position.x;
        float enemyX = context.transform.position.x;
        float dist = enemyX - playerX;

        // Calcula o offset alvo (esquerda ou direita do player)
        float targetOffset = dist > 0f ? desiredDistance : -desiredDistance;
        float targetX = playerX + targetOffset;

        float deltaX = targetX - enemyX;
        float absDeltaX = Mathf.Abs(deltaX);

        // Se estiver dentro da toler�ncia de chegada, zera X e inicia hold/ataque
        if (absDeltaX <= arrivalTolerance)
        {
            // Parar o movimento horizontal (gravidade continua)
            context.rb.linearVelocity = new Vector2(0f, context.rb.linearVelocity.y);

            // Se houver hold configurado, inicia o timer
            if (holdTimeOnArrival > 0f)
                holdTimer = holdTimeOnArrival;

            // Opcional: se voc� tem um m�todo de ataque no context, chama aqui:
            // context.TryMeleeAttack(); // descomente se implementar
            Debug.Log("Attacar após aproximar");

            return;
        }

        // Dire��o normalizada no eixo X (-1 ou 1)
        float directionX = Mathf.Sign(deltaX);

        // Desejada velocidade horizontal
        float desiredVelX = directionX * context.moveSpeed * speedMultiplier;

        // Para movimento mais suave, fazemos MoveTowards do velocity atual para desiredVel
        float currentVelX = context.rb.linearVelocity.x;
        float accel = Mathf.Max(5f, context.moveSpeed * 8f); // acelera��o, ajuste � necessidade
        float newVelX = Mathf.MoveTowards(currentVelX, desiredVelX, accel * Time.deltaTime);

        // Aplica a nova velocidade (mantendo y)
        context.rb.linearVelocity = new Vector2(newVelX, context.rb.linearVelocity.y);
    }
}
