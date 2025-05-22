using System.Collections;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] GameObject weapon;
    [SerializeField] private float attackSpeed;
    [SerializeField] private bool canAttack = true;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && canAttack == true)
        {
            StartCoroutine(Attacking());
        }
    }

    private IEnumerator Attacking()
    {
        canAttack = false;
        weapon.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        weapon.SetActive(false);
        yield return new WaitForSeconds(attackSpeed);
        canAttack = true;
    }
}
