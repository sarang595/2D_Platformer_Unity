using UnityEngine;
using UnityEngine.UI;
public class HealthSlider : MonoBehaviour
{
    [SerializeField] private PlayerControl playerControl;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    private float maxHealth = 100f; // Define max health

    void Start()
    {
        totalHealthBar.fillAmount = 1f; // Total health bar should always be full
    }

    void Update()
    {
        currentHealthBar.fillAmount = playerControl.PlayerHealth() / maxHealth;
    }
}
