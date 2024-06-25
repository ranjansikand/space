// Base script for any object that can hold gold

using UnityEngine;

public class GoldInventory : MonoBehaviour
{
    public virtual int storedOre { get; set; } = 0;

    public virtual void AddOre(int amount) {
        storedOre += amount;
    }
}
