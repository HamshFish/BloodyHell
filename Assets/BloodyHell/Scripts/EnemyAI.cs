using System;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    public GameObject moveToObject;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        moveToObject = GameObject.Find("Player");
    }

    void Update()
    {
        if (agent != null && moveToObject != null)
        {
            agent.destination = moveToObject.transform.position;
        }
    }
}
