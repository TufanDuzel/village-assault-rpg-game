using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    // Declares a Health class that handles the health of game characters.
    public class Health : MonoBehaviour
    {
        // Initializes maximum health to 100.
        [SerializeField] float health = 100f;

        // Flag to check if the character is dead.
        bool isDead = false;

        // Returns if the character is dead.
        public bool IsDead()
        {
            return isDead;
        }

        // Reduces health by the damage amount and checks for death.
        public void TakeDamage(float damage)
        {
            // Ensures health never drops below zero.
            health = Mathf.Max(health - damage, 0);

            // Calls Die() function if health reaches zero.
            if (health == 0)
            {
                Die();
            }
        }

        // Handles the character's death.
        private void Die()
        {
            // Checks if already dead to prevent retriggering death.
            if (isDead == true)
            {
                return;
            }

            // Marks the character as dead.
            isDead = true;

            // Triggers death animation.
            GetComponent<Animator>().SetTrigger("die");

            // Stops any current actions.
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }
    }

}
