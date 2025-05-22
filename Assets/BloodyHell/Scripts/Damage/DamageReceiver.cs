using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DamageReceiver : MonoBehaviour
{
    //[Header("References")]
    //[SerializeField] private Renderer render;
    [SerializeField] private HealthColor healthColor;

    [Header("Health")]
    [SerializeField] private float healthMax;
    [SerializeField] public float currentHealth;

    //private Color _100health = Color.green;
    //private Color _25health = Color.red;


    public UnityEvent onOutOfHealth;


    public void Start()
    {
        //start at full health
        currentHealth = healthMax;

    }

    public void TakeDamage(float damage)
    {
        // our new health after taking damage is our old health - damage, not going below 0
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, healthMax);

        healthColor.Apply();

        // if we run out of health
        if (currentHealth <= 0)
        {
            Debug.Log("running end of life");
            EndOfLife();
        }
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, healthMax);
    }

    private void EndOfLife()
    {
        Debug.Log(gameObject + " has died");

        onOutOfHealth.Invoke();
    }

    public float GetHealthPercent()
    {
        return currentHealth / healthMax;
    }


    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void BossDeath()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayerDeath()
    {
        SceneManager.LoadScene(2);
    }
}
