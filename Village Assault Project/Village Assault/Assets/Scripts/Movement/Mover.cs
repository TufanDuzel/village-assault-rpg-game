using RPG.Combat;
using RPG.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    // Manages movement behaviors for characters using the Unity Navigation system.
    public class Mover : MonoBehaviour, IAction
    {

        void Start()
        {

        }

        // Update is called once per frame to continually update character movement.
        void Update()
        {
            UptadeAnimator();
        }

        // Initiates movement to a new destination and cancels any existing combat actions.
        public void StartMoveAction(Vector3 hit)
        {
            // Cancels current fighting actions.
            GetComponent<Fight>().Cancel();

            // Moves the character to the new destination.
            GetComponent<NavMeshAgent>().destination = hit;
            GetComponent<NavMeshAgent>().isStopped = false;
        }

        // Moves the character to the specified position.
        public void MoveTo(Vector3 hit)
        {
            // Sets the NavMeshAgent's destination.
            GetComponent<NavMeshAgent>().destination = hit;

            // Ensures the NavMeshAgent is moving towards the destination.
            GetComponent<NavMeshAgent>().isStopped = false;
        }

        public void Cancel()
        {
            // Stops the NavMeshAgent from moving.
            GetComponent<NavMeshAgent>().isStopped = true;
        }

        // Updates the animator with the current movement speed.
        private void UptadeAnimator()
        {
            // Gets the current velocity from the NavMeshAgent.
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;

            // Converts velocity to local space.
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);

            // Uses the z component for forward speed.
            float speed = localVelocity.z;

            // Sets the speed in the animator to control animations.
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }
    }
}
