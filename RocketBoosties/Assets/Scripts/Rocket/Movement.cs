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
    private float _lerpSpeed = 1.0f;
    
    // Used on Update().
    private Rigidbody _theRigidbody;
    private Vector3 _startingRotation;
    private Vector3 _targetRotation;
    private float _inputData = 0f;
    private void OnEnable()
    {
        inputThrust.Enable();  
        inputRot.Enable();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _theRigidbody = GetComponent<Rigidbody>();
        _startingRotation = this.gameObject.transform.eulerAngles;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckForThrust();
        CheckForRotation();
    }

    void CheckForThrust()
    {
        if (inputThrust.IsPressed() && _theRigidbody)
        {
            
            _theRigidbody.AddRelativeForce(this.gameObject.transform.up * (thrustForce * Time.fixedDeltaTime));
        }
    }

    void CheckForRotation()
    {
        _inputData = inputRot.ReadValue<float>();
        if (_inputData != 0.0f)
        {
            _startingRotation = this.gameObject.transform.eulerAngles;
            _targetRotation = _startingRotation;
            _targetRotation.z += (_inputData * (rotationSpeed * Time.fixedDeltaTime));
       
            // Don't want to rotate while we're telling the rocket to rotate.
            _theRigidbody.freezeRotation = true;
            this.gameObject.transform.eulerAngles = Vector3.Lerp(_startingRotation, _targetRotation, _lerpSpeed);
            _theRigidbody.freezeRotation = false;
        }
        
        
        //this.gameObject.transform.Rotate(Vector3.forward * (inputRot.ReadValue<float>() * (rotationSpeed * Time.fixedDeltaTime)));
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
