using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Characters
{
    [CreateAssetMenu(menuName = ("RPG/Special Abiltiy/Self Heal"))]
    public class SelfHealConfig : AbilityConfig
	{
		[Header("Self Heal Specific")]
		[SerializeField] float extraHealth = 50f;

        public override AbilityBehaviour GetBehaviourComponent(GameObject objectToattachTo)
        {
            return objectToattachTo.AddComponent<SelfHealBehaviour>();
        }

        public float GetExtraHealth()
		{
			return extraHealth;
		}
	}
}