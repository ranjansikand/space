// Scriptable object to spawn gold


using System.Collections;
using UnityEngine;


public class GoldSpawner : ScriptableObject
{
    [SerializeField] GoldOre goldPrefab;

    WaitForSeconds timeBetweenSpawns = new WaitForSeconds(0.25f);

    public IEnumerator SpawnGoldOres(Transform origin, float radius, int amountNeeded, Transform destination, bool instant = false) {
        int amountIssued = 0;

        while (amountIssued < amountNeeded) {
            Vector2 position = origin.position + (Random.insideUnitSphere * radius);
            GoldOre newOre = Instantiate(goldPrefab, position, Quaternion.identity);

            int value = Mathf.Min(amountNeeded - amountIssued, 5);
            amountIssued += value;

            newOre.OnSpawn(origin, value, destination);

            if (instant) yield return null;
            else yield return timeBetweenSpawns;
        }
    }
}
