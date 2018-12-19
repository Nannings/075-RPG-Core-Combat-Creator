using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.weapons
{
    [CreateAssetMenu(menuName = ("RPG/Weapon"))]
    public class Weapon : ScriptableObject
    {

        public Transform gripTransform;

        [SerializeField] GameObject weaponPrefab;
        [SerializeField] AnimationClip attackAnimation;

        public GameObject GetWeaponPrefab()
        {
            return weaponPrefab;
        }

        public AnimationClip GetAttackAnimClip()
        {
            StripAnimationEvents();
            return attackAnimation;
        }

        private void StripAnimationEvents()
        {
            attackAnimation.events = new AnimationEvent[0];
        }
    }
}