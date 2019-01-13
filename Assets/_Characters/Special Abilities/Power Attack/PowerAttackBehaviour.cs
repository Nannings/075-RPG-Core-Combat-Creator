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

        public override void Use(AbilityUseParams useParams)
        {
            PlayAbilitySound();
            print("Power attack used by: " + gameObject.name);
            DealDamage(useParams);
            PlayParticleEffect(); // TODO find way of moving audio to parent class
        }

        private void DealDamage(AbilityUseParams useParams)
        {
            float damageToDeal = useParams.baseDamage + (config as PowerAttackConfig).GetExtraDamage();
            useParams.target.TakeDamage(damageToDeal);
        }
    }
}