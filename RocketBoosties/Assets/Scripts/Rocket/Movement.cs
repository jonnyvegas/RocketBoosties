using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private InputAction thrust;
    private void OnEnable()
    {
        thrust.Enable();   
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (thrust.IsPressed())
        {
            Debug.Log("Something witty to the console");
        }
    }
}
