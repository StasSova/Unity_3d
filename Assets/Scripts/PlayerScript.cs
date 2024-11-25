using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float forceFactor = 5f;
    private InputAction _moveAction;
    private Rigidbody _rb;
    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
        _moveAction = InputSystem.actions.FindAction("Move");
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveValue = _moveAction.ReadValue<Vector2>();
        Vector3 correctedForward = _camera.transform.forward;
        correctedForward.y = 0.0f;
        correctedForward.Normalize();
        
        Vector3 forceValue = forceFactor * ( // относительно камеры
            _camera.transform.right * moveValue.x +
            correctedForward * moveValue.y
        );
        // new Vector3(moveValue.x, 0.0f, moveValue.y) // относительно мира;
        _rb.AddForce(forceValue);
    }
}
