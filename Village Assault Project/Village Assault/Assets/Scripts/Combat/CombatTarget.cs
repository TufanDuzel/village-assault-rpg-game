using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;

namespace RPG.Combat
{
    // This class marks an object as a valid target for combat interactions.

    // Ensures that a Health component is attached to the object.
    [RequireComponent(typeof(Health))]
    public class CombatTarget : MonoBehaviour
    {

    }
}
