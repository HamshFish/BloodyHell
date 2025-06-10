using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Movement movement;
    [SerializeField] private Image staminaBar;

    [Header("Stamina")]
    [SerializeField] private float maxStamina = 100f;
    [SerializeField] private float currentStamina;
    [SerializeField] private bool hasRegenerated = true;
    [SerializeField] private bool isSprinting = false;
    //[SerializeField] private bool canSprint = true;

    [Header("Stamina Regen")]
    [SerializeField] private float staminaDrain = 0.5f;
    [SerializeField] private float staminaRegen = 0.5f;

    


    private void Start()
    {
        currentStamina = maxStamina;
    }

    private void Update()
    {
        staminaBar.fillAmount = currentStamina / maxStamina;
        

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Sprinting();
        }
        else
        {
            isSprinting = false;
        }

        movement.currentSpeed = isSprinting ? movement.sprintSpeed : movement.walkSpeed;

        if (!isSprinting)
        {
            if(currentStamina <= maxStamina)
            {
                currentStamina += staminaRegen * Time.deltaTime;

                if(currentStamina >= maxStamina)
                {
                    hasRegenerated = true;
                }
            }
        }
    }

    private void Sprinting()
    {
        if (hasRegenerated)
        {
            isSprinting = true;
            currentStamina -= staminaDrain * Time.deltaTime;
        }

        if(currentStamina <= 0)
        {
            hasRegenerated = false;
            isSprinting = false;
        }
    }
}
