// Script that spawns asteroids and replaces gold ones after they're mined


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    // Prefabs
    [SerializeField] GameObject[] asteroids;
    [SerializeField] GoldAsteroid[] goldAsteroids;

    // Spawning variables
    [SerializeField] float spawnRadius = 40f;
    [SerializeField] int minAsteroids = 12, maxAsteroids = 22;
    [SerializeField, Range(0, 1)] float percentGold = 0.1f;

    List<GoldAsteroid> golden = new List<GoldAsteroid>();


    private void OnEnable() {
        int totalAsteroids = Random.Range(minAsteroids, maxAsteroids);
        int numberGold = Mathf.CeilToInt(percentGold * totalAsteroids);
        int asteroidsToSpawn = totalAsteroids - numberGold;


        for (int i = 0; i < numberGold; i++) {
            Vector2 spawnPos = Random.insideUnitCircle * spawnRadius;
            GoldAsteroid newGold = Instantiate(
                goldAsteroids[Random.Range(0, goldAsteroids.Length)], 
                spawnPos, Quaternion.identity, transform);
            golden.Add(newGold);
        }

        for (int i = 0; i < asteroidsToSpawn; i++) {
            Vector2 spawnPos = Random.insideUnitCircle * spawnRadius;
            Instantiate(
                asteroids[Random.Range(0, goldAsteroids.Length)], 
                spawnPos, Quaternion.identity, transform);
        }
    }
}
