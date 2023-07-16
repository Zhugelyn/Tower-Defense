using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed = 20f;
    [SerializeField]
    public float _rotationSpeed = 180f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        _rigidbody.AddForce(movement * _movementSpeed);
    }

    private void Update()
    {
        // Управление поворотом
        bool rotateLeft = Input.GetKey(KeyCode.Q);
        bool rotateRight = Input.GetKey(KeyCode.E);

        if (rotateLeft)
        {
            transform.Rotate(Vector3.up, -_rotationSpeed * Time.deltaTime);
        }
        else if (rotateRight)
        {
            transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
        }
    }
}