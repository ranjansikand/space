// Special asteroid that can be mined for gold


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldAsteroid : MonoBehaviour, IInteractable
{
    [SerializeField] GoldSpawner gs;
    [SerializeField] int oreValue = 10;

    public void Interact(GameObject obj) {
        StartCoroutine(gs.SpawnGoldOres(transform, 1.25f, oreValue, obj.transform, true));
        Invoke(nameof(DestroyThis), 0.15f);    
    }

    void DestroyThis() {
        Destroy(gameObject);
    }
}
