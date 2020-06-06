using System;
using UnityEngine;

public class ShipMove : MonoBehaviour
{
    enum Direction
    {
        Left,
        Right
    }

    private SpriteRenderer _spriteRenderer;
    private Direction _direction = Direction.Right;

    [Tooltip("The left most screen position the ship is allowed")]
    public float _leftMostX = -0.3f;

    [Tooltip("The right most screen position the ship is allowed")]
    public float _rightMostX = 0.3f;

    [Tooltip("Horizontal speed multiplier")]
    public float _horizontalMultiplier = 1.5f;

    [Tooltip("The top most screen position the ship is allowed")]
    public float _topExtreme = 1.25f;

    [Tooltip("The bottom most screen position the ship is allowed")]
    public float _bottomExtreme = 0.75f;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        var direction = Input.GetAxis("Horizontal");
        if (direction < 0)
        {
            _direction = Direction.Left;
        }
        else if (direction > 0)
        {
            _direction = Direction.Right;
        }

        DoHorizontal();
        DoVertical();
    }

    void DoVertical()
    {
        var y = Input.GetAxis("Vertical");
        var offset = new Vector3(0, y * Time.deltaTime * 0.5f, 0);
        transform.position += offset;

        if (transform.position.y > _topExtreme)
        {
            transform.position = SetY(_topExtreme);
        }
        else if (transform.position.y < _bottomExtreme)
        {
            transform.position = SetY(_bottomExtreme);
        }
    }

    void DoHorizontal()
    {
        var left = _direction == Direction.Left;
        var dirMost = left ? _rightMostX : _leftMostX;
        _spriteRenderer.flipX = left;

        Func<float, float, bool> boundsHit = RightExtreme;
        if (left)
        {
            boundsHit = LeftExtreme;
        }

        var target = SetX(dirMost);
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * _horizontalMultiplier);
        if (boundsHit(transform.position.x, dirMost))
        {
            transform.position = SetX(dirMost);
        }
    }

    /// <summary>
    /// Check if the player has hit the left-most edge of the screen.
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="extreme"></param>
    /// <returns></returns>
    private bool LeftExtreme(float pos, float extreme)
    {
        return pos > extreme;
    }

    /// <summary>
    /// Check if the player has hit the right-most edge of the screen.
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="extreme"></param>
    /// <returns></returns>
    private bool RightExtreme(float pos, float extreme)
    {
        return pos < extreme;
    }

    private Vector3 SetX(float x)
    {
        return new Vector3(x, transform.position.y, transform.position.z);
    }

    private Vector3 SetY(float y)
    {
        return new Vector3(transform.position.x, y, transform.position.z);
    }
}
