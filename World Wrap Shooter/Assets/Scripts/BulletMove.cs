using System;
using System.Collections;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float _duration = 0.5f;

    public float _direction = 1;
    public Action _onKill;

    IEnumerator Start()
    {
        var t = 0f;
        while (t < 1f)
        {
            transform.position += (Vector3.right * _direction) * (Time.deltaTime / _duration);

            t += Time.deltaTime / _duration;
            yield return null;
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Lander")
        {
            var lander = collision.GetComponent<Lander>();
            lander?.Kill();
            _onKill?.Invoke();
            Destroy(gameObject);
        }
    }
}
