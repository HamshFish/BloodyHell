using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    public GameObject moveToObject;
    private NavMeshAgent agent;

    [SerializeField] private float[] speedlist = new float[5];
    public int enemySpeed;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        moveToObject = GameObject.Find("Player");

        enemySpeed = Random.Range(0, 4);
        agent.speed = speedlist[enemySpeed];
    }

    void Update()
    {
        if (agent != null && moveToObject != null)
        {
            agent.destination = moveToObject.transform.position;
        }
    }

}
