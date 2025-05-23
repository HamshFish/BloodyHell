using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {

            gameObject.SetActive(true);
            transform.LookAt(player.transform);
    }


}
