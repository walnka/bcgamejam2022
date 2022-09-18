using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNotSelected : StateMachineBehaviour
{
    DragController dc;
    float timer;
    float direction;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        dc = animator.gameObject.GetComponent<DragController>();
        timer = 0f;
        direction = 1f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (dc.canBeMoved)
        {
            animator.transform.RotateAround(animator.gameObject.transform.position, Vector3.up, 100f * Time.deltaTime);
            if (timer >= dc.bobTimer)
            {
                direction *= -1f;
                timer = 0f;
            }
            animator.transform.position = new Vector3(animator.transform.position.x,
                animator.transform.position.y + direction * Time.deltaTime,
                animator.transform.position.z);
            timer += Time.deltaTime;
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.rotation = Quaternion.identity;  
        animator.transform.position = new Vector3(animator.transform.position.x,
            0,
            animator.transform.position.z);
        dc.canBeMoved = false;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
