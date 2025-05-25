using UnityEngine;

public class LookAtEnable : MonoBehaviour
{
    [SerializeField] private GameObject enable;
    [SerializeField] private EnemyAI ai;

    private void Update()
    {
        if (ai.isPlayerClose)
        {
            enable.SetActive(true);
        }
    }
}
