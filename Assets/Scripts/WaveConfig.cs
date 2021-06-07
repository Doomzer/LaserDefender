using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float spawnTime = 0.5f;
    [SerializeField] float spawnRand = 0.3f;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] int enemyNumber = 5;
    [SerializeField] bool isInfinitePath = true;

    public GameObject GetEnemyPrefab() { return enemyPrefab; }
    public List<Transform> GetWaypoints()
    {
        var waypoints = new List<Transform>();
        foreach (Transform waypint in pathPrefab.transform)
            waypoints.Add(waypint);

        return waypoints;
    }
    public float GetSpawnTime() { return spawnTime; }
    public float GetSpawnRand() { return spawnRand; }
    public float GetMoveSpeed() { return moveSpeed; }
    public int GetEnemyNumber() { return enemyNumber; }
    public bool IsInfinite() { return isInfinitePath; }
}
