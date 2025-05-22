using UnityEngine;

public class OnEnemyDeath : MonoBehaviour
{
    [SerializeField] private GameObject wisp;

    private void OnDisable()
    {
        // on disable spawn wisp object at enemy location
        Instantiate(wisp, gameObject.transform.position, Quaternion.identity);
    }
}
