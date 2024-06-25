// Override to give player animations

using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] ParticleSystem hurtEffect;
    [SerializeField] Screenshake screenshake;
    int hurtHash;

    private void Awake() {
        hurtHash = Animator.StringToHash("Hurt");
    }

    protected override void OnCollisionEnter2D(Collision2D other) {
        base.OnCollisionEnter2D(other);
    }

    protected override void Damage(float damage) {
        base.Damage(damage);

        PlayerData.animator.SetTrigger(hurtHash);
        hurtEffect.Play();
        screenshake.Play(Mathf.Clamp01(damage / 10f));

        if (PlayerData.inventory.storedOre > 0) {
            int goldLost = (int)Mathf.Min(PlayerData.inventory.storedOre, damage);
            PlayerData.inventory.storedOre -= goldLost;
            StartCoroutine(PlayerData.inventory.spawner.SpawnGoldOres(transform, 1.25f, goldLost, null));
        }
    }
}
