using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Slider healthBar;
    public Text scoreText;

    private int score;
    private float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        score = 0;
        UpdateHealthBar();
        UpdateScoreText();
    }

    void Update()
    {
        // Just for demonstration, let's decrease health and increase score over time
        currentHealth -= Time.deltaTime * 5f; // Decrease health over time
        if (currentHealth < 0) currentHealth = 0;

        score += (int)(Time.deltaTime * 10); // Increase score over time

        UpdateHealthBar();
        UpdateScoreText();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0) currentHealth = 0;
        UpdateHealthBar();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    private void UpdateHealthBar()
    {
        healthBar.value = currentHealth / maxHealth;
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
