// Home-base where you deposit all your ores

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mothership : GoldInventory, IInteractable
{
    [SerializeField] public AudioSource audioSource;
    [SerializeField] AudioClip goldGainedSound, goldLostSound;
    [SerializeField] GoldSpawner spawner;

    // Ore storage
    [SerializeField] GameObject canvas;
    [SerializeField] TMP_Text counter;

    int _storedOre = 0;
    public override int storedOre {
        get { return _storedOre; }
        set {
            if (value > _storedOre) audioSource.PlayOneShot(goldGainedSound, PlayerData.maxSFXVolume); 
            else audioSource.PlayOneShot(goldLostSound, PlayerData.maxSFXVolume);
            _storedOre = value;
            counter.text = _storedOre.ToString();
        }
    }

    // Gravity field
    float playerDrag;
    [SerializeField] float forceFieldDrag = 1.1f;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == 6) {  
            // Player
            playerDrag = PlayerData.rb.drag;
            PlayerData.rb.drag = forceFieldDrag;

            canvas.SetActive(true);
            counter.text = storedOre.ToString();
        } else if (other.gameObject.layer == 7) {  
            // Asteroid
            Vector2 awayDirection = (other.transform.position - transform.position).normalized;
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(awayDirection, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.layer == 6) {
            // Revert player "gravity" when exiting the forcefield
            PlayerData.rb.drag = playerDrag;

            // Hide Canvas
            canvas.SetActive(false);
        }
    }


    public void Interact(GameObject obj) {
        // Take the money
        StartCoroutine(spawner.SpawnGoldOres(obj.transform, 1.25f, PlayerData.inventory.storedOre, transform));
        PlayerData.inventory.storedOre = 0;
    }
}
