using UnityEngine;

public class EnemyUtilityAI : MonoBehaviour
{
    public UtilityAction[] actions;
    
    private EnemyContext context;

    private void Start()
    {
        context = GetComponent<EnemyContext>();
    }

    private void Update()
    {
        UtilityAction best = null;
        float bestScore = 0f;

        if(context.globalCooldown > 0)
        {
            context.globalCooldown -= Time.deltaTime;
            return;
        }

        if (context.executing) return;

        //Debug.Log("Escolheu uma action");

        foreach (var action in actions)
        {
            float score = action.Score(context) * action.weight;

            if (score > bestScore)
            {
                best = action;
                bestScore = score;
            }
        }

        if (best != null)
            best.Execute(context);
    }
}
