using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameObject ball;
    [SerializeField] private Ball ballScript;
    [SerializeField] private SpriteRenderer spr;
    [SerializeField] private float speed = 5f;
    private bool holdMoveRight = false;
    private bool holdMoveLeft = false;
    #endregion

    #region Methods
    #region Internal Methods
    private void Update()
    {
        if (holdMoveRight)
        {
            gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0);
        }

        if (holdMoveLeft)
        {
            gameObject.transform.position += new Vector3(-speed * Time.deltaTime, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the collided object was the ball then trigger it's player bounce
        if (collision.gameObject == ball)
        {
            float dist = collision.transform.position.x - transform.position.x;
            dist *= (1 / spr.bounds.extents.x); // dist is normalized here so that the horizontal point furthest away from the center is now equal to 1 (or -1 on the left)
            ballScript.PlayerBounce(dist);
        }
    }
    #endregion

    #region External Methods
    public void MoveRight(InputAction.CallbackContext ctx)
    {
        if (ctx.performed) holdMoveRight = true;
        else if (ctx.canceled) holdMoveRight = false;
    }

    public void MoveLeft(InputAction.CallbackContext ctx) 
    {
        if (ctx.performed) holdMoveLeft = true;
        else if (ctx.canceled) holdMoveLeft = false;
    }
    #endregion
    #endregion
}
