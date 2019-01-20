﻿﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Characters
{
    [RequireComponent(typeof(Character))]
    [RequireComponent(typeof(WeaponSystem))]
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] float chaseRadius = 6f;

        PlayerMovement player = null;
        Character character;
        float currrentWeaponRange;
        float distanceToPlayer;

        enum State { idle, patrolling, attacking, chasing};
        State state = State.idle;

        void Start()
        {
            character = GetComponent<Character>();
            player = FindObjectOfType<PlayerMovement>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                Time.timeScale = 0;
            }

            distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            WeaponSystem weaponSystem = GetComponent<WeaponSystem>();
            currrentWeaponRange = weaponSystem.GetCurrentWeapon().GetMaxAttackRange();
            if(distanceToPlayer > chaseRadius && state != State.patrolling)
            {
                StopAllCoroutines();
                state = State.patrolling;
            }
            if (distanceToPlayer <= chaseRadius && state != State.chasing)
            {
                StopAllCoroutines();
                StartCoroutine(ChasePlayer());
            }
            if(distanceToPlayer <= currrentWeaponRange && state != State.attacking)
            {
                StopAllCoroutines();
                state = State.attacking;
            }
        }

        IEnumerator ChasePlayer()
        {
            state = State.chasing;
            while (distanceToPlayer >= currrentWeaponRange)
            {
                character.SetDestination(player.transform.position);
                yield return new WaitForEndOfFrame();
            }
        }

        void OnDrawGizmos()
        {
            // Draw attack sphere 
            Gizmos.color = new Color(255f, 0, 0, .5f);
            Gizmos.DrawWireSphere(transform.position, currrentWeaponRange);

            // Draw chase sphere 
            Gizmos.color = new Color(0, 0, 255, .5f);
            Gizmos.DrawWireSphere(transform.position, chaseRadius);
        }
    }
}