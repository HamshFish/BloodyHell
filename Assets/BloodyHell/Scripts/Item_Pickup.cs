using UnityEngine;

public class Item_Pickup : MonoBehaviour
{
    private DamageReceiver damageReceiver;

    private void Start()
    {
        damageReceiver = GetComponent<DamageReceiver>();
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wisp")
        {
            Debug.Log("Wisp infused.");
            damageReceiver.Heal(20);
            Destroy(other.gameObject);
        }
    }
}
