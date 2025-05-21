using UnityEngine;

public class HealthColor : MonoBehaviour
{
    [SerializeField] private Gradient gradient;

    private Renderer render;
    private DamageReceiver damage;

    private void Start()
    {
        render = GetComponent<Renderer>();
        damage = GetComponent<DamageReceiver>();
    }

    private void Update()
    {
        Apply();
    }

    public void Apply()
    {
        render.material.color = gradient.Evaluate(damage.GetHealthPercent());
    }
}
