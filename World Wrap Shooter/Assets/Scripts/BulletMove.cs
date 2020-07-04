using System.Collections;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float _duration = 0.5f;

    public float _direction = 1;

    // Start is called before the first frame update
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
}
