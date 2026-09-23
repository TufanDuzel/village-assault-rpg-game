using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    // Defines a class that schedules actions for game characters.
    public class ActionScheduler : MonoBehaviour
    {
        // Holds the current action being performed.
        IAction currentAction;

        // Starts a new action and cancels the previous one if its different.
        public void StartAction(IAction action)
        {
            // Checks if the new action is the same as the current one.
            if (currentAction == action)
            {
                // Stops further execution if the action hasn't changed.
                return;
            }

            // If there is a current action, cancels it before starting a new one.
            if (currentAction != null)
            {
                currentAction.Cancel();
            }

            // Sets the new action as the current action.
            currentAction = action;
        }

        // Cancels the current action.
        public void CancelCurrentAction()
        {
            // Calls StartAction with null to cancel any action.
            StartAction(null);
        }
    }
}
