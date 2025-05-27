using UnityEngine;

public class SelfDamage : MonoBehaviour
{
    [SerializeField] private DamageReceiver damageReceiver;

    private void OnParticleCollision()
    {
        damageReceiver.TakeDamage(20);
    }
}
