// Static script for player's components


using System.Collections;
using UnityEngine;
using TMPro;

public class PlayerData : MonoBehaviour
{
    // Scripts
    public static PlayerController controller;
    public static PlayerHealth health;
    public static PlayerInventory inventory;

    // Components
    public static Animator animator;
    public static Rigidbody2D rb;
    public static AudioSource audiosource;

    public static WaitForSeconds updateCheck = new WaitForSeconds(0.1f);

    public static float maxSFXVolume = 0.5f;


    [SerializeField] TMP_Text coordinates, velocity;

    private void Awake() {
        // Scripts
        controller = GetComponent<PlayerController>();
        health = GetComponent<PlayerHealth>();
        inventory = GetComponent<PlayerInventory>();
        
        // Components
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audiosource = GetComponent<AudioSource>();
    }

    private void Start() {
        StartCoroutine(UpdateCoordinates());
    }

    private IEnumerator UpdateCoordinates() {
        while (true) {
            string xCoord = transform.position.x.ToString("0");
            string yCoord = transform.position.y.ToString("0");

            coordinates.text = "(" + xCoord + ", " + yCoord + ")";
            velocity.text = rb.velocity.magnitude.ToString("0.00") + " m/s";

            yield return updateCheck;
        }
    }
}
