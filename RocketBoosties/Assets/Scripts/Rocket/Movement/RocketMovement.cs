using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class RocketMovement : MonoBehaviour, IRocketMovement
{
    // Which input we'd like to use for thrust. Set it in the script.
    [SerializeField] private InputAction inputThrust;
    // Input for rotation. Set in script.
    [SerializeField] private InputAction inputRot;
    
    [SerializeField] private float thrustForce = 1.0f;
    
    [SerializeField] private float rotationSpeed = 1.0f;
    [SerializeField] private float timeBeforeDisableMovement = 0f;
    private float _lerpSpeed = 1.0f;
    
    // Used on Update() methods. Cached refs (i.e., not set in editor).
    private Rigidbody _theRigidbody;
    private Vector3 _startingRotation;
    private Vector3 _targetRotation;
    private float _inputData = 0f;
    private IRocketAudioManager _rocketAudioRef;
    private IEnumerator _disableMovementCoroutine;
    private bool _bDoPress = false;
    private bool _bMovementEnabled = false;
    private IRocketParticleManager _particleManager;
    
    private void OnEnable()
    {
        EnableMovement();
    }

    private void EnableMovement()
    {
        inputThrust.Enable();  
        inputRot.Enable();
        _bMovementEnabled = true;
        //Debug.Log("Movement Enabled");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _theRigidbody = GetComponent<Rigidbody>();
        _startingRotation = this.gameObject.transform.eulerAngles;
        if (TryGetComponent(out IRocketAudioManager rocketAudio))
        {
            _rocketAudioRef = rocketAudio;
            
        }

        if (TryGetComponent(out IRocketParticleManager particleManager))
        {
            _particleManager = particleManager;
        }
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
            if (!_bDoPress)
            {
                _bDoPress = true;
                _rocketAudioRef.PlayOrStopThrustSfx(true);
                _particleManager.PlayOrStopThrustParticles(true);
            }
           
        }
        else
        {
            _bDoPress = false;
            _rocketAudioRef.PlayOrStopThrustSfx(false);
            _particleManager.PlayOrStopThrustParticles(false);
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

    public void InvokeDisableMovement()
    {
        //Debug.Log("disabling movement");
        _disableMovementCoroutine = DisableMovement(timeBeforeDisableMovement);
        StartCoroutine(_disableMovementCoroutine);
    }

    private IEnumerator DisableMovement(float timeToWaitBeforeDisabling)
    {
        yield return new WaitForSeconds(timeToWaitBeforeDisabling);
        _bMovementEnabled = false;
        inputThrust.Disable();
        inputRot.Disable();
    }

    public bool MovementEnabled()
    {
        return _bMovementEnabled;
    }
}
