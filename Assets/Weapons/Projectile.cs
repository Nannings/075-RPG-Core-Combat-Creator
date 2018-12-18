using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField] float projectileSpeed; // Note other classes can set

    const float DESTROY_DELAY = 0.01f;
    [SerializeField] GameObject shooter;
    float damageCaused;

    public void SetShooter(GameObject shooter)
    {
        this.shooter = shooter;
    }

    public void SetDamage(float damage)
    {
        damageCaused = damage;
    }

    void OnCollisionEnter(Collision collision)
    {
        var layerCollideWith = collision.gameObject.layer;
        if (layerCollideWith != shooter.layer)
        {
            DamageIfDamageables(collision);
        }
    }

    private void DamageIfDamageables(Collision collision)
    {
        Component damagableComponent = collision.gameObject.GetComponent(typeof(IDamageable));
        if (damagableComponent)
        {
            (damagableComponent as IDamageable).TakeDamage(damageCaused);
        }
        Destroy(gameObject, DESTROY_DELAY);
    }

    internal float GetDefaultLaunchSpeed()
    {
        return projectileSpeed;
    }
}
