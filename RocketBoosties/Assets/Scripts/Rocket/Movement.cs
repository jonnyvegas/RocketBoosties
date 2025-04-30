using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private InputAction thrust;
    private Rigidbody theRigidbody;
    private void OnEnable()
    {
        thrust.Enable();   
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        theRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (thrust.IsPressed() && theRigidbody)
        {
            theRigidbody.AddRelativeForce(new Vector3(0, 0.01f, 0));
        }
    }
}
