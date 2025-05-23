using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    public GameObject moveToObject;
    private NavMeshAgent agent;

    [SerializeField] private float[] speedlist = new float[5];
    public int enemySpeed;
    [HideInInspector] public bool isPlayerClose;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        moveToObject = GameObject.Find("Player");

        enemySpeed = Random.Range(0, speedlist.Length);
        agent.speed = speedlist[enemySpeed];

    }

    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, moveToObject.transform.position) <= 50f)
        {
            isPlayerClose = true;
        }

        if (agent != null && moveToObject != null && isPlayerClose)
        {
            agent.destination = moveToObject.transform.position;
        }

    }

}
