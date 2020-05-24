using UnityEngine;

public class CamMove : MonoBehaviour
{
    private float _z;
    private Vector3 _position;

    [Tooltip("The speed of the camera")]
    public float _speed;

    [Tooltip("The position of the left-most screen from the perspective of the camera")]
    public float _left = -1.5f;

    [Tooltip("The position of the right-most screen from the perspective of the camera")]
    public float _right = 1.5f;

    [Tooltip("The left most position allowed by the camera in the world")]
    private float _leftMax = -2.5f;

    [Tooltip("The right most position allowed by the camera in the world")]
    private float _rightMax = 2.5f;

    [Tooltip("The left trailing camera")]
    public Transform _leftCam;

    [Tooltip("The right leading camera")]
    public Transform _rightCam;

    void Start()
    {
        _z = transform.position.z;
        _position = transform.position;
        _speed = 1;
    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        _position += Vector3.right * horizontal * _speed * Time.deltaTime;

        if (_position.x < _leftMax)
        {
            _position = new Vector3(_right, 0, _z);
        }

        if (_position.x > _rightMax)
        {
            _position = new Vector3(_left, 0, _z);
        }
    }

    private void LateUpdate()
    {
        transform.position = _position;
        _leftCam.position = new Vector3(-4f, 0, _z) + transform.position;
        _rightCam.position = new Vector3(4, 0, _z) + transform.position;
    }
}
