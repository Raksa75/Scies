using UnityEngine;

public class DiscSpawner : MonoBehaviour
{
    public GameObject discPrefab;  // Le prefab de la scie
    public float spawnInterval = 3f;  // Intervalle de temps entre chaque spawn
    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnDisc();
            nextSpawnTime = Time.time + spawnInterval; // Mise à jour correcte de l'heure du prochain spawn
        }
    }

    void SpawnDisc()
    {
        // Instancier une nouvelle scie au centre de la salle
        Instantiate(discPrefab, transform.position, Quaternion.identity);
    }
}
