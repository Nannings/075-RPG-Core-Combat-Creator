﻿﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Characters
{
    public class PowerAttackBehaviour : AbilityBehaviour
    {
        // Use this for initialization
        void Start()
        {
            print("Power Attack behaviour attached to " + gameObject.name);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void Use(GameObject target)
        {
            PlayAbilitySound();
            print("Power attack used by: " + gameObject.name);
            DealDamage(target);
            PlayParticleEffect(); // TODO find way of moving audio to parent class
            PlayAbilityAnimation();
        }

        private void DealDamage(GameObject target)
        {
            float damageToDeal = (config as PowerAttackConfig).GetExtraDamage();
            target.GetComponent<HealthSystem>().TakeDamage(damageToDeal);
        }
    }
}