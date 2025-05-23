using UnityEngine;

public class DamageSource : MonoBehaviour
{
    public enum Apply
    {
        Instant,
        Overtime
    }

    public enum Type
    {
        Standerd,
        // Bleed // Maybe
    }

    [SerializeField] private GameObject[] wispBossChance;

    [Header("Damage")]
    [SerializeField] public int damageAmount;
    [SerializeField] private Apply apply;
    [SerializeField] private Type type;

    private void DealDamage(GameObject target)
    {
        // if we find the damage receiver component, AND the target is not on the same layer as us
        if(target.GetComponent<DamageReceiver>() &&  target.layer != gameObject.layer)
        {
            target.GetComponent<DamageReceiver>().TakeDamage(damageAmount);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        DealDamage(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        DealDamage(other.gameObject);
    }

    private void OnParticleCollision(GameObject other)
    {
        DealDamage(other);
    }
}
