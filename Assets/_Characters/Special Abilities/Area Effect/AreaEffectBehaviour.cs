using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Characters;
using RPG.Core;
using System;

public class AreaEffectBehaviour : MonoBehaviour, ISpecialAbility {

    AreaEffectConfig config;
    AudioSource audioSource = null;

    public void SetConfig(AreaEffectConfig configToSet)
    {
        this.config = configToSet;
    }

	// Use this for initialization
	void Start () {
		print("Area Effect behaviour attached to " + gameObject.name);
        audioSource = GetComponent<AudioSource>();
    }
	

    public void Use(AbilityUseParams useParams)
    {
        DealRadialDamage(useParams);
        PlayParticleEffect();
        audioSource.clip = config.GetAudioClip();
        audioSource.Play();
    }

    private void PlayParticleEffect()
    {
        var prefab = Instantiate(config.GetParticlePrefab(), transform.position, Quaternion.identity);
        ParticleSystem myParticleSystem = prefab.GetComponent<ParticleSystem>();
        myParticleSystem.Play();
        Destroy(prefab, myParticleSystem.main.duration);
    }

    private void DealRadialDamage(AbilityUseParams useParams)
    {
        print("Area Effect used by " + gameObject.name);
        // Static sphere cast for targets
        RaycastHit[] hits = Physics.SphereCastAll(
            transform.position,
            config.GetRadius(),
            Vector3.up,
            config.GetRadius()
        );

        foreach (RaycastHit hit in hits)
        {
            var damageable = hit.collider.gameObject.GetComponent<IDamageable>();
            bool hitPlayer = hit.collider.gameObject.GetComponent<Player>();
            if (damageable != null && !hitPlayer)
            {
                float damageToDeal = useParams.baseDamage + config.GetDamageToEachTarget(); // TODO ok Rick?
                damageable.TakeDamage(damageToDeal);
            }
        }
    }
}
