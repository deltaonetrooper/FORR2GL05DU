using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs; // Listi af dýrategundum sem hægt er að spawna

    private float spawnRangeX = 20; // Breiddin á spawna svæðinu í X-ás
    private float spawnPosZ = 20; // Z-ás staðsetning fyrir spawna

    private float startDelay = 2; // Tími sem bíður áður en spawna fer af stað
    private float spawnInterval = 1.5f; // Tími á milli hverrar spawna

    // Start er kallað einu sinni áður en fyrsta keyrslu Update fer fram eftir að MonoBehaviour er búin til
    void Start()
    {
        // Byrjar að spawna dýr á reglulegu millibili
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update er kallað einu sinni fyrir hverja mynd (frame)
    void Update()
    {

    }

    // Spawna dýr á tilviljunarkenndri staðsetningu
    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length); // Velur tilviljunarkenndan dýraforrita frá listanum
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ); // Býr til tilviljunarkennda staðsetningu
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation); // Spawnar dýrinu á staðsetningunni
    }
}
