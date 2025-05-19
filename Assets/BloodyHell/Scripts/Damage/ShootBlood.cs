using UnityEngine;

public class ShootBlood : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject bloodGO;
    private ParticleSystem blood;
    private DamageSource damage;

    [Header("Power")]
    public int shootPower;
    [SerializeField] private float shootSpeed;
    [SerializeField] private int minRoll = 1;
    [SerializeField] private int maxRoll = 20;


    private void Start()
    {
        blood = bloodGO.GetComponentInChildren<ParticleSystem>();
    }



    private void Projectile()
    {
        RollD20();
        ParticleSystem spawnedBlood = Instantiate(blood, transform.position,  transform.rotation * Quaternion.Euler(110f,0f,0f));
        damage = FindAnyObjectByType<DamageSource>();
        damage.damageAmount = shootPower;
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicked");
            Projectile();
        }
        
    }
    private void RollD20()
    {
        shootPower = Random.Range(minRoll, maxRoll);
        Debug.Log("D20 Rolled");
    }
}
