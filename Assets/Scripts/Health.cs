// Script for any object that has health
// Applies damage through collisions


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class Health : MonoBehaviour
{
    Rigidbody2D rb;

    // Invulnerability
    Coroutine invulnerabilityRoutine;
    protected WaitForSeconds invulnerabilityTime = new WaitForSeconds(0.5f);
    bool invulnerable = false;
    

    int maxHealth = 10;
    int currentHealth;
    float collisionDamageScale = 2.5f;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision) {
        Vector3 impactVelocity = collision.relativeVelocity;
        float magnitude = Mathf.Max(0f, impactVelocity.magnitude);
        float damage = magnitude * collisionDamageScale;

        if (damage > 1f && !invulnerable) Damage(damage);
    }

    protected virtual void Damage(float damage) {
        Debug.Log("Damage: " + damage);

        
        if (invulnerabilityRoutine == null)
            invulnerabilityRoutine = StartCoroutine(Invulnerability());
    }

    IEnumerator Invulnerability() {
        invulnerable = true;

        yield return invulnerabilityTime;

        invulnerable = false;
        invulnerabilityRoutine = null;
    }
}
