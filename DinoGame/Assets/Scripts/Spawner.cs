using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObject 
    {
        public GameObject prefab;
        [Range(0f, 1f)]
        public float spawnChange;
    }

    public SpawnableObject[] objects;

    public float minSpawnRate = 1f;
    public float maxSpawnRate = 2f;

    private void OnEnable()
    {
        Invoke(nameof(Spawn),Random.Range(maxSpawnRate,minSpawnRate));
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
    void Spawn()
    {
        float spawnChance = Random.value;


        foreach (var obj in objects)
        {
            if (spawnChance < obj.spawnChange)
            {
                GameObject obstacle = Instantiate(obj.prefab);
                obstacle.transform.position += transform.position;
                break;
            }

            spawnChance -= obj.spawnChange;
        }
        Invoke(nameof(Spawn), Random.Range(maxSpawnRate, minSpawnRate));
    }



}
