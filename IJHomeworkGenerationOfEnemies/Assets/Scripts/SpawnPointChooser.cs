using Random = System.Random;
using UnityEngine;

public class SpawnPointChooser : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;

    public Vector3 GetSpawnerPoint()
    {
        Random random = new();
        int minForRandom = 0;
        int maxForRandom = _spawnPoints.Length;

        return _spawnPoints[random.Next(minForRandom, maxForRandom)].position;
    }
}

