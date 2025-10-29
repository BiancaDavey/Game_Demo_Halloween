using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rigidbody;
    Vector2 playerMovement;
    private bool movementDisabled = false;

    void Update()
    {
        if (!movementDisabled)
        {
            playerMovement.x = Input.GetAxisRaw("Horizontal");
            playerMovement.y = Input.GetAxisRaw("Vertical");
            //  Disable diagonal movement.
            if (playerMovement.x != 0) playerMovement.y = 0;
        }
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + playerMovement * speed * Time.fixedDeltaTime);
    }

    public void EnableDisableMovement(bool update)
    {
        movementDisabled = update;
    }
}
