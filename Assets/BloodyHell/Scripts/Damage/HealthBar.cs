using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private DamageReceiver damageReceiver;

    private Image healthBar;

    private void Start()
    {
        healthBar = GetComponent<Image>();
    }

    private void Update()
    {
        healthBar.fillAmount = damageReceiver.GetHealthPercent();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            damageReceiver.Heal(20);
        }
    }
}
