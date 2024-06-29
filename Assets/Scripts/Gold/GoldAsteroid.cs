// Special asteroid that can be mined for gold


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldAsteroid : MonoBehaviour, IInteractable
{
    [SerializeField] GoldSpawner gs;
    [SerializeField] ParticleSystem burst;
    [SerializeField] int oreValue = 10;

    AsteroidSpawner spawner;

    public void Setup(AsteroidSpawner s) {
        spawner = s;
    }

    public void Interact(GameObject obj) {
        StartCoroutine(gs.SpawnGoldOres(transform, 1.25f, oreValue, obj.transform, true));
        burst.Play();
        Invoke(nameof(DestroyThis), 0.15f);    
    }

    protected virtual void DestroyThis() {
        spawner.Relocate(this);
        gameObject.SetActive(false);
    }
}
