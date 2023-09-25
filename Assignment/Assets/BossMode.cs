using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMode : StateMachineBehaviour
{
    private List<string> triggerNames = new List<string> { "Idle", "Melee", "Attack", "Laser", "Defend", "Defend2" };
    private string lastTrigger = "";

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Remove the last used trigger from the list
        if (!string.IsNullOrEmpty(lastTrigger))
        {
            triggerNames.Remove(lastTrigger);
        }

        // If all triggers have been used, reset the list
        if (triggerNames.Count == 0)
        {
            triggerNames = new List<string> { "Idle", "Melee", "Attack", "Laser", "Defend", "Defend2" };
        }

        // Randomly select a trigger from the remaining list
        int rand = Random.Range(0, triggerNames.Count);
        string selectedTrigger = triggerNames[rand];

        // Set the selected trigger and store it as the last used trigger
        animator.SetTrigger(selectedTrigger);
        lastTrigger = selectedTrigger;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
