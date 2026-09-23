using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    // Defines a Fight class that handles combat interactions for characters.
    public class Fight : MonoBehaviour, IAction
    {
        // Time between attacks.
        [SerializeField] float timeBetweenAttacks = 1f;

        // The maximum range of an attack.
        [SerializeField] float weaponRange;

        // The damage an attack can deal.
        [SerializeField] float weaponDamage = 10f;

        Health targetObject;
        float timeSinceLastAttack;

        private void Update()
        {
            // Increase the time since the last attack.
            timeSinceLastAttack += Time.deltaTime;

            // If no target exists, exit the function.
            if (targetObject == null)
            {
                return;
            }

            // If the target is dead, reset attack trigger and cancel actions.
            if (targetObject.IsDead() == true)
            {
                GetComponent<Animator>().ResetTrigger("attack");
                Cancel();

                return;
            }

            // Move to the target if not within attack range; otherwise, attack.
            if (GetIsInRange() == false)
            {
                GetComponent<Mover>().MoveTo(targetObject.transform.position);
            }
            else
            {
                Attacking();
                GetComponent<Mover>().Cancel();
            }
        }

        // Handles the attacking mechanism by checking attack cooldown and facing the target.
        private void Attacking()
        {
            // Face the target object.
            transform.LookAt(targetObject.transform);

            // Check if enough time has passed since the last attack to initiate a new attack.
            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                TriggerAttack();
                timeSinceLastAttack = 0;
            }

            // Trigger the attack animation.
            GetComponent<Animator>().SetTrigger("attack");
        }

        // Determines if the character is able to attack the target.
        public bool CanAttack(GameObject combatTarget)
        {
            // Return false if no combat target is set.
            if (combatTarget == null)
            {
                return false;
            }

            // Check the health of the combat target to ensure they're alive for attack.
            Health healthToTest = GetComponent<Health>();
            return healthToTest != null && !healthToTest.IsDead();
        }

        // Initiates the attack on a specified target.
        public void Attack(GameObject target)
        {
            // Start the attack action and set the target object.
            GetComponent<ActionScheduler>().StartAction(this);
            targetObject = target.GetComponent<Health>();
        }

        // Triggers the actual attack through the animator.
        private void TriggerAttack()
        {
            // Reset stop attack and set attack triggers for animation.
            GetComponent<Animator>().ResetTrigger("stopAttack");
            GetComponent<Animator>().SetTrigger("attack");
        }

        // Handles hitting the target during the attack animation.
        void Hit()
        {
            // Exit if no target object is set.
            if (targetObject == null)
            {
                return;
            }

            // Deal damage to the target object.
            targetObject.TakeDamage(weaponDamage);
        }

        // Checks if the target is within the weapon's attack range.
        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, targetObject.transform.position) < weaponRange;
        }

        // Cancels any ongoing actions and clears the target.
        public void Cancel()
        {
            StopAttack();
            targetObject = null;
        }

        // Resets the attack triggers to stop the attack animations.
        private void StopAttack()
        {
            GetComponent<Animator>().ResetTrigger("attack");
            GetComponent<Animator>().SetTrigger("stopAttack");
        }
    }
}
