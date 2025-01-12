using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Reference to the UI Image or Slider
    public Slider healthSlider; // Optional if using a Slider
    public Image healthFill;    // Optional if using an Image

    public string enemyObjects;
    public GameObject character;

    // Current and maximum health
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth;

    void Start()
    {
        // Initialize health
        currentHealth = maxHealth;

        // Update the health bar display
        UpdateHealthBar();
    }

    void Update()
    {
        UpdateHealthBar();
    }

    // Method to take damage
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Update the health bar
        UpdateHealthBar();
    }

    // Method to heal
    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Update the health bar
        UpdateHealthBar();
    }

    // Update the visual health bar
    private void UpdateHealthBar()
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth / maxHealth; // Slider value is normalized
        }

        if (healthFill != null)
        {
            healthFill.fillAmount = currentHealth / maxHealth; // Fill image works similarly
        }
    }
}
