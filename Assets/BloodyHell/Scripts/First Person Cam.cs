using UnityEngine;

public class FirstPersonCam : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] Transform playerTransform;

    [Header("Sensitivity")]
    [SerializeField] float sens;

    [Header("Rotation")]
    [SerializeField] float minRotation = -30f;
    [SerializeField] float maxRotation = 60f;

    [Header("CameraPosition")]
    [SerializeField] float playerEyeOffset = 0.5f;

    private float currentHorizontalRotation;
    private float currentVerticalRotation;

    private void Start()
    {
        currentHorizontalRotation = transform.localEulerAngles.y;
        currentVerticalRotation = transform.localEulerAngles.x;
    }

    private void Update()
    {
        //allows us to look around
        currentHorizontalRotation += Input.GetAxis("Mouse X") * sens;
        currentVerticalRotation -= Input.GetAxis("Mouse Y") * sens;

        // verticle rotation is us looking up and down so we clamp it
        currentVerticalRotation = Mathf.Clamp(currentVerticalRotation, minRotation, maxRotation);

        Vector3 newRotation = new Vector3();
        //putting the rotations into a new vector 3
        newRotation.x = currentVerticalRotation;
        newRotation.y = currentHorizontalRotation;

        // grabbing the new vector 3 we just made and making it so we move the way were facing instead of the world
        transform.localEulerAngles = newRotation;

        //make the cam go to the player
        transform.position = playerTransform.position;
        //go to the eyes
        transform.position += Vector3.up * playerEyeOffset;
    }
}
