using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent SpawnStartingEnemies;
    [SerializeField] private GameObject[] enemys;

    private void Start()
    {
        RunEnemiesEvent();
    }

    public void StartingEnemies()
    {
        Vector3 randomSpawnPostion = new Vector3(Random.Range(286, 414), 1, Random.Range(347, 749));
        Instantiate(enemys[0], randomSpawnPostion, Quaternion.identity);
    }

    private void RunEnemiesEvent()
    {
        SpawnStartingEnemies.Invoke();
    }
}
