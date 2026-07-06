using TMPro;
using UnityEngine;

public class GameResultUI : MonoBehaviour
{
    [SerializeField] private TMP_Text title;

    private void Start()
    {
        switch (GameSession.Result)
        {
            case GameResult.Victory:
                title.text = "Vitória!";
                title.color = Color.white;
                break;

            case GameResult.Defeat:
                title.text = "Game Over";
                title.color = Color.red;
                break;
        }
    }
}
