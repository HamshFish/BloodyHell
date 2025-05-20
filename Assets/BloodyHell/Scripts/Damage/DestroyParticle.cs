using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    private ParticleSystem particle;

    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (particle != null && !particle.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}
