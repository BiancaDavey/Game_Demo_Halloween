using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rigidbody;
    public Animator animator;
    Vector2 playerMovement;
    private bool movementOff = false;

    void Update()
    {
        if (!movementOff)
        {
            playerMovement.x = Input.GetAxisRaw("Horizontal");
            playerMovement.y = Input.GetAxisRaw("Vertical");
            //  Disable diagonal movement.
            if (playerMovement.x != 0) playerMovement.y = 0;
            //  Apply animation based on player movement.
            animator.SetFloat("Horizontal", playerMovement.x);
            animator.SetFloat("Vertical", playerMovement.y);
            animator.SetFloat("Speed", playerMovement.sqrMagnitude);
        }
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + playerMovement * speed * Time.fixedDeltaTime);
    }

    public void SetMovementOnOff(bool update)
    {
        movementOff = update;
    }
}
