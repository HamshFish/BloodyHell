using UnityEngine;

public class OnEnemyDeath : MonoBehaviour
{
    [SerializeField] private GameObject wisp;

    public void SpawnWisp()
    {
        // on disable spawn wisp object at enemy location
        Instantiate(wisp, gameObject.transform.position, Quaternion.identity);
    }
}
