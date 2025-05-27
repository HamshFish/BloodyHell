using System.Collections;
using UnityEngine;

public class HealthParticle : MonoBehaviour
{
    [SerializeField] private GameObject particle;


    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            particle.SetActive(true);
        }   
    }

    private IEnumerator OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            particle.GetComponent<ParticleSystem>().Stop();
            yield return new WaitForSeconds(1);
            particle.GetComponent<ParticleSystem>().Play();
            particle.SetActive(false);
        }
    }
}
