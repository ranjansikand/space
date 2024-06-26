// Inventory system
// Allows player to store ores


using UnityEngine;
using TMPro;

public class PlayerInventory : GoldInventory
{
    public GoldSpawner spawner;
    [SerializeField] TMP_Text counter;
    [SerializeField] AudioClip pickupSound;

    int _storedOre = 0;
    public override int storedOre {
        get { return _storedOre; }
        set {
            _storedOre = value;
            counter.text = _storedOre.ToString();
        }
    }

    private void Start() {
        storedOre = 0;
    }

    public override void AddOre(int amount) {
        storedOre += amount;
        PlayerData.audiosource.PlayOneShot(pickupSound, PlayerData.maxSFXVolume);
    }
}
