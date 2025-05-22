using UnityEngine;

public class OnEnemyDeath : MonoBehaviour
{
    [SerializeField] private GameObject wisp;
    [SerializeField] private GameObject enemy;

    public void SpawnWisp()
    {
        // on disable spawn wisp object at enemy location
        Instantiate(wisp, gameObject.transform.position, Quaternion.identity);
    }

    public void SpawnEnemy()
    {
        Vector3 randomSpawnPostion = new Vector3(Random.Range(286, 414), 1, Random.Range(347, 749));
        Instantiate(enemy, randomSpawnPostion, Quaternion.identity);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
