using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Combat;
using RPG.Core;

namespace RPG.Controller
{
    // Defines an AIController class that handles the behavior of AI characters.
    public class AIController : MonoBehaviour
    {
        // Defines the chase distance to engage with the player.
        [SerializeField] float chaseDistance = 5f;

        // References.
        GameObject player;
        Fight fight;
        Health health;

        void Start()
        {
            // Finds and assigns the player object by searching for the "Player" tag.
            player = GameObject.FindWithTag("Player");

            // Gets the Fight component attached to this GameObject.
            fight = GetComponent<Fight>();

            // Gets the Health component attached to this GameObject.
            health = GetComponent<Health>();
        }

        void Update()
        {
            // Checks if the AI is dead, if so, exits the function to stop processing.
            if (health.IsDead())
            {
                return;
            }

            // Checks if the player is within the chase distance and can be attacked.
            if (DistanceToPlayer() < chaseDistance && fight.CanAttack(player))
            {
                // If conditions are met, the AI attacks the player.
                fight.Attack(player);
            }
            else
            {
                // If conditions are not met, cancels any current combat actions.
                fight.Cancel();
            }
        }

        // Calculates the distance from the AI to the player.
        private float DistanceToPlayer()
        {
            // Returns the distance between the AI's position and the player's position.
            return Vector3.Distance(player.transform.position, transform.position);
        }
    }

}