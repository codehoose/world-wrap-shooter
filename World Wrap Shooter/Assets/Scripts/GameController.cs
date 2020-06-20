using System;
using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Spawner[] _spawners;

    public int _spawnCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var spawner in _spawners)
        {
            if (!spawner._spawnOnEnter)
            {
                spawner.Spawn(_spawnCount);
            }
            else
            {
                spawner.ShipEntered += Spawner_ShipEntered;
            }
        }
    }

    void Spawner_ShipEntered(object sender, EventArgs e)
    {
        var spawner = sender as Spawner;
        if (spawner != null)
        {
            spawner.ShipEntered -= Spawner_ShipEntered;
            StartCoroutine(SpawnItems(spawner));
        }
    }

    IEnumerator SpawnItems(Spawner spawner)
    {
        if (spawner._spawnDelay > 0)
        {
            yield return new WaitForSeconds(spawner._spawnDelay);
        }

        spawner.Spawn(_spawnCount);
    }
}
