using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ShipMove))]
public class LaserFireControl : MonoBehaviour
{
    private ShipMove _shipMove;

    public GameObject _laserPrefab;

    public float _offset = 0.39f;

    public float _cooldown = 0.5f;

    // Start is called before the first frame update
    void Awake()
    {
        _shipMove = GetComponent<ShipMove>();
    }

    // Update is called once per frame
    IEnumerator Start()
    {
        while (true)
        {
            if (Input.GetButton("Fire1"))
            {
                var pos = transform.position + new Vector3(_offset * _shipMove.SignedDirection, 0);
                var copy = Instantiate(_laserPrefab, pos, Quaternion.identity);
                var bulletMove = copy.GetComponent<BulletMove>();
                bulletMove._direction = _shipMove.SignedDirection;
                bulletMove._onKill = () => _shipMove.AlienKilled();
                copy.GetComponent<SpriteRenderer>().flipX = _shipMove.SignedDirection < 0;
                yield return new WaitForSeconds(_cooldown);
            }
            else
            {
                yield return null;
            }
        }
    }
}
