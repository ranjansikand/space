// Static script for player's components


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // Scripts
    public static PlayerController controller;
    public static PlayerHealth health;
    public static PlayerInventory inventory;

    // Components
    public static Animator animator;
    public static Rigidbody2D rb;

    private void Awake() {
        // Scripts
        controller = GetComponent<PlayerController>();
        health = GetComponent<PlayerHealth>();
        inventory = GetComponent<PlayerInventory>();
        
        // Components
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
}
