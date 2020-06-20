using UnityEngine;

public class LanderSpawner : Spawner
{
    protected override void SpawnObject(GameObject obj, Vector3 pos)
    {
        obj.transform.position = pos;
        obj.SetActive(true);
    }
}
