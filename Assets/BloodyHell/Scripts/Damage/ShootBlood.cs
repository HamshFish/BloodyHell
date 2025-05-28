using TMPro;
using UnityEngine;

public class ShootBlood : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject bloodGO;
    [SerializeField] private GameObject nat1BloodGo;
    [SerializeField] private GameObject nat20BloodGo;
    [SerializeField] private DamageReceiver damageReceiver;

    private ParticleSystem blood;
    private ParticleSystem nat1Blood;
    private ParticleSystem nat20Blood;
    private DamageSource damage;
    [SerializeField] private TMP_Text text;
    [SerializeField] private Animator anim;


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
        nat1Blood = nat1BloodGo.GetComponentInChildren<ParticleSystem>();
        nat20Blood = nat20BloodGo.GetComponentInChildren<ParticleSystem>();
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
            if (roll == 1)
            {
                ParticleSystem spawnedNat1Blood = Instantiate(nat1Blood, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, 0f)); // spawn partricle
            }
            else if (roll == 20)
            {
               ParticleSystem spawnedNat20Blood = Instantiate(nat20Blood, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, 0f));
            }
            else
            {
                ParticleSystem spawnedBlood = Instantiate(blood, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, 0f));
            }
            
                //Debug.Log("taking self damage");
                damageReceiver.TakeSelfDamage(30);
        }
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicked");
            Projectile();
            text.text = roll.ToString();
            anim.Play("RollAnim");
            
        }
        
    }
    private void RollD20()
    {
        roll = Random.Range(minRoll, maxRoll);
        //Debug.Log("D20 Rolled");
    }

    
}
