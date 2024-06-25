// Fragments of gold ore that are spawned and move to target


using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GoldOre : MonoBehaviour
{
    Rigidbody2D rb;
    CircleCollider2D cc;

    // Giving player gold
    [SerializeField] LayerMask playerMask;
    public int oreValue { get; set; } = 5;
    float movementSpeed = 2.5f;
    

    // Coroutines
    WaitForSeconds startDelay = new WaitForSeconds(1f);
    WaitForSeconds checkDelay = new WaitForSeconds(0.15f);
    Coroutine interactionRoutine = null;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CircleCollider2D>();

        cc.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GoldInventory inv = other.gameObject.GetComponent<GoldInventory>();

        if (inv != null) {
            inv.AddOre(oreValue);
            Destroy(gameObject);
        }
    }

    public void OnSpawn(Transform creator, int value, Transform target) {
        oreValue = value;

        // Add slight movement force
        Vector2 awayDirection = (transform.position - creator.transform.position).normalized;
        rb.AddForce(awayDirection * 0.25f, ForceMode2D.Impulse);

        if (target != null) interactionRoutine = StartCoroutine(GoToTarget(target));
        else StartCoroutine(CheckForPlayer());
    }

    private IEnumerator GoToTarget(Transform destination) {
        yield return startDelay;
        cc.enabled =  true;

        while (true) {
            // Update velocity to face toward player every .15 seconds
            Vector2 direction = -1 * (transform.position - destination.position).normalized;
            rb.velocity = direction * movementSpeed;
            yield return checkDelay;
        }
    }

    private IEnumerator CheckForPlayer() {
        yield return startDelay;

        while (interactionRoutine == null) {
            // Check for player in radius
            Collider2D[] results = new Collider2D[10];
            int numberOfResults = Physics2D.OverlapCircleNonAlloc(transform.position, 2f, results, playerMask);

            // Stop checking and go to player if found
            if (numberOfResults > 0)
                interactionRoutine = StartCoroutine(GoToTarget(PlayerData.controller.transform));
            
            yield return checkDelay;
        }
    }
}
