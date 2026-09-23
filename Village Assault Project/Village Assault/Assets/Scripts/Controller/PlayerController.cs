using RPG.Movement;
using RPG.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;

namespace RPG.Controller
{
    // Manages the player's interactions with the game world.
    public class PlayerController : MonoBehaviour
    {
        // Health component of the player.
        Health health;

        public void Start()
        {
            health = GetComponent<Health>();
        }

        void Update()
        {
            // If the player is dead, stop processing inputs.
            if (health.IsDead() == true)
            {
                return;
            }

            // Check for combat interactions.
            if (InteractWithCombat() == true)
            {
                return;
            }

            // Check for movement interactions.
            if (InteractWithMovement() == true)
            {
                return;
            }
        }

        // Processes combat interactions with the environment.
        private bool InteractWithCombat()
        {
            // Cast a ray for each frame and gather all hits.
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach(RaycastHit hit in hits)
            {
                // Attempt to get the CombatTarget component from the hit object.
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();

                // Continue to the next hit if no target is found.
                if (target == null)
                {
                    continue;
                }

                // Check if the target is attackable. If not, continue to the next hit.
                if (!GetComponent<Fight>().CanAttack(target.gameObject))
                {
                    continue;
                }

                if (target == null)
                {
                    continue;
                }

                // If the left mouse button is pressed, initiate an attack.
                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fight>().Attack(target.gameObject);
                }

                // Return true to stop further processing of interactions.
                return true;
            }

            // Return false if no combat interactions occurred.
            return false;
        }

        // Processes movement interactions with the environment.
        private bool InteractWithMovement()
        {
            RaycastHit hit;

            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            //Debug.Log(hasHit);

            // If the raycast hits something and the left mouse button is held, initiate movement.
            if (hasHit)
            {
                if(Input.GetMouseButton(0))
                {
                    Debug.Log("Moved!");
                    GetComponent<Mover>().StartMoveAction(hit.point);
                }

                // Return true to indicate that movement was processed.
                return true;
            }

            // Return false if no movement interactions occurred.
            return false;
        }

        // Utility method to create a ray from the mouse's position on the screen.
        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}
