using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform target;
    [SerializeField] private Rigidbody rb;

    private void Update()
    {
        transform.LookAt(target);

        rb.linearVelocity = new Vector3(1, 0);
    }
}
