using UnityEngine;

public class ShootBlood : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject bloodGO;
    [SerializeField] private DamageReceiver damageReceiver;
    private ParticleSystem blood;
    private DamageSource damage;
    

    [Header("Power")]
    public int shootPower;
    public int roll;
    [SerializeField] private float shootSpeed;
    [SerializeField] private int minRoll = 1;
    [SerializeField] private int maxRoll = 20;

    public int[] d20Rolls = new int[20];

    private void Start()
    {
        blood = bloodGO.GetComponentInChildren<ParticleSystem>();
    }



    private void Projectile()
    {
        if(damageReceiver.currentHealth >= 30)
        {
            //Debug.Log("Rolling D20");
            RollD20();
            //Debug.Log("setting shoot power to roll");
            shootPower = d20Rolls[roll]; // put roll into damage
            //Debug.Log("spawning particle");
            ParticleSystem spawnedBlood = Instantiate(blood, transform.position,  transform.rotation * Quaternion.Euler(110f,0f,0f)); // spawn partricle
            //Debug.Log("taking self damage");
            damageReceiver.TakeDamage(30);
        }
        
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
        roll = Random.Range(minRoll, maxRoll);
        //Debug.Log("D20 Rolled");
    }

    
}
