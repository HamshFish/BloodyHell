using UnityEngine;

public class Item_Pickup : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wisp")
        {
            Debug.Log("Wisp infused.");
            Destroy(other.gameObject);
        }
    }
}
