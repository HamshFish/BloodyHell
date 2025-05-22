using System.Xml;
using UnityEngine;

public class AttackDMG : MonoBehaviour
{
    private DamageSource damage;
    private ShootBlood shootBlood;

    void Awake()
    {
        damage = GetComponent<DamageSource>();
        shootBlood = FindFirstObjectByType<ShootBlood>();

        damage.damageAmount = shootBlood.shootPower;
    }
}
