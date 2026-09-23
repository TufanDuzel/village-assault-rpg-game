using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    // This class ensures the camera follows the player throughout the game.
    public class TrackingCamera : MonoBehaviour
    {
        // Reference to the player's transform for tracking position.
        [SerializeField] Transform player;

        // Called after all Update functions have been processed.
        void LateUpdate()
        {
            // Updates the camera's position to match the player's position each frame.
            transform.position = player.position;
        }
    }
}
