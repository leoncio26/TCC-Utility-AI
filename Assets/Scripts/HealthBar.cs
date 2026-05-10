using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillHealthBar;
    public float changeSpeed = 10.0f;

    public float fillAmount { get; set; } = 1.0f;

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        fillHealthBar.fillAmount = currentHealth / maxHealth;
    }
}
