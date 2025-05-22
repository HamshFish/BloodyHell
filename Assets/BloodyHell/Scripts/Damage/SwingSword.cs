using UnityEngine;

public class SwingSword : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private Camera cam;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(weapon, gameObject.transform.position, cam.transform.rotation);
        }
    }
}
