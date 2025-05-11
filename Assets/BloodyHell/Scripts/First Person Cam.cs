using UnityEngine;

public class FirstPersonCam : MonoBehaviour
{
    [SerializeField] float sens;

    [SerializeField] Transform playerTransform;

    [SerializeField] float minRotation = -30f;
    [SerializeField] float maxRotation = 60f;

    [SerializeField] float playerEyeOffset = 0.5f;

    private float currentHorizontalRotation;
    private float currentVerticalRotation;

    private void Start()
    {
        currentHorizontalRotation = transform.localEulerAngles.y;
        currentVerticalRotation = transform.localEulerAngles.x;
    }

   
}
