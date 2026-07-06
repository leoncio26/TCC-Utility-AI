using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
}
