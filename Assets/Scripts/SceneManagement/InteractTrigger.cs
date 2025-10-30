using System;
using UnityEngine;

public class InteractTrigger : MonoBehaviour
{
    [HideInInspector] public bool triggerOn = false;
    [HideInInspector] public bool interacted = false;
    public bool animateOnce;
    public Animator animator;

    public void TriggerAnimation(){
        animator.SetBool("animate", true);
    }

    public void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            triggerOn = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Player")){
            triggerOn = false;
        }
    }
    
    public void Update(){
        if (triggerOn && Input.GetKeyDown(KeyCode.E)){
            if (!animateOnce){
                TriggerAnimation();
                //  Implement.
            }
            if (animateOnce && !interacted){
                TriggerAnimation();
                interacted = true;
            }
        }
    }
}