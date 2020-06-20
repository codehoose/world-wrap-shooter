using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] _objects;

    public GameObject[] _spawnPoints;

    [Tooltip("Set this to true to spawn the items when the area is entered")]
    public bool _spawnOnEnter = false;

    [Tooltip("Number of seconds after entry that items are spawned")]
    public float _spawnDelay = 1f;

    public event EventHandler ShipEntered;

    public void Spawn(int count)
    {
        List<GameObject> _pool = new List<GameObject>(_spawnPoints);
        for (var i = 0; i < count; i++)
        {
            // Get random spawn point
            var index = UnityEngine.Random.Range(0, _pool.Count);
            var spawn = _pool[index];
            // Remove spawn point from list
            _pool.RemoveAt(index);

            // Set object to world space of spawn point
            SpawnObject(_objects[i], spawn.transform.position);
        }
    }

    public void ShipTouch()
    {
        ShipEntered?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void SpawnObject(GameObject obj, Vector3 pos)
    {
        obj.transform.position = pos;
    }
}
