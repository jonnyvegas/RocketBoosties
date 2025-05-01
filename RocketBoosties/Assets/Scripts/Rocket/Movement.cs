using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{
    // Which input we'd like to use for thrust. Set it in the script.
    [FormerlySerializedAs("thrust")] [SerializeField] private InputAction inputThrust;
    // Input for rotation. Set in script.
    [SerializeField] private InputAction inputRot;
    
    [SerializeField] private float thrustForce = 1.0f;
    
    [SerializeField] private float rotationSpeed = 1.0f;
    
    // Used on Update().
    private Rigidbody _theRigidbody;
    private Vector3 _theRotation;
    private void OnEnable()
    {
        inputThrust.Enable();  
        inputRot.Enable();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _theRigidbody = GetComponent<Rigidbody>();
        _theRotation = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForThrust();
        CheckForRotation();
    }

    void CheckForThrust()
    {
        if (inputThrust.IsPressed() && _theRigidbody)
        {
            
            _theRigidbody.AddRelativeForce(this.gameObject.transform.up * (thrustForce * Time.deltaTime));
        }
    }

    void CheckForRotation()
    {
        _theRotation.z = inputRot.ReadValue<float>() * Time.deltaTime * rotationSpeed;
        //Debug.Log(theRotation.z + " is the rotation");
        this.gameObject.transform.Rotate(_theRotation);
    }
    float GetThrustForce()
    {
        return thrustForce;
    }

    void SetThrustForce(float force)
    {
        thrustForce = force;
    }
}
