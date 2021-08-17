using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator playerAnimator;
    Rigidbody2D rb;

    public Vector2 movement;
    public float playerSpeed = 5;


    #region Animator Parameters
    bool playerIsMoving = false;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        movement.x = Input.GetAxisRaw("Horizontal"); // -1 is left
        movement.y = Input.GetAxisRaw("Vertical"); // -1 is down
        playerIsMoving = movement.x == 0 ? movement.y == 0 ? false : true : true;
        playerAnimator.SetBool("PlayerIsMoving", playerIsMoving);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
        
    }
}
