using UnityEngine;

[RequireComponent(typeof(ShipMove))]
public class LaserFireControl : MonoBehaviour
{
    private ShipMove _shipMove;

    public GameObject _laserPrefab;

    public float _offset = 0.39f;

    // Start is called before the first frame update
    void Awake()
    {
        _shipMove = GetComponent<ShipMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var pos = transform.position + new Vector3(_offset * _shipMove.SignedDirection, 0);
            var copy = Instantiate(_laserPrefab, pos, Quaternion.identity);
            copy.GetComponent<BulletMove>()._direction = _shipMove.SignedDirection;
            copy.GetComponent<SpriteRenderer>().flipX = _shipMove.SignedDirection < 0;
        }
    }
}
