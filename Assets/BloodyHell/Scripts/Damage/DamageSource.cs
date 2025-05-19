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
        Bleed // Maybe
    }

    [Header("References")]
    [SerializeField] private Apply apply;
    [SerializeField] private Type type;

    [Header("Damage")]
    [SerializeField] private float damageAmount;


    private void DealDamage(GameObject target)
    {
        // if we find the damage receiver component, AND the target is not on the same layer as us
        if(target.GetComponent<DamageReceiver>() &&  target.layer != gameObject.layer)
        {
            target.GetComponent<DamageReceiver>().TakeDamage(damageAmount);
        }
    }

    private void OnCollisionEnter(Collision collision)
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
