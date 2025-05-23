using UnityEngine;
using UnityEngine.SceneManagement;

public class OnEnemyDeath : MonoBehaviour
{
    [SerializeField] private GameObject wisp;
    [SerializeField] private GameObject[] enemys;
    [SerializeField] private GameObject[] extraEnemyChance;

    public void SpawnWisp()
    {
        // on disable spawn wisp object at enemy location
        Vector3 wispSpawnPosition = new Vector3(gameObject.transform.position.x, 1, gameObject.transform.position.z);
        Instantiate(wisp, wispSpawnPosition, Quaternion.identity);
    }

    public void SpawnEnemy()
    {
        Vector3 randomSpawnPostion = new Vector3(Random.Range(286, 414), 1, Random.Range(347, 749));
        Instantiate(enemys[Random.Range(0, enemys.Length)], randomSpawnPostion, Quaternion.identity);
    }

    public void SpawnExtraEnemy()
    {
        Debug.Log("EXTRA BOIS");
        Vector3 randomSpawnPostion = new Vector3(Random.Range(286, 414), 1, Random.Range(347, 749));
        Instantiate(extraEnemyChance[Random.Range(0, extraEnemyChance.Length)], randomSpawnPostion, Quaternion.identity);
    }

}
