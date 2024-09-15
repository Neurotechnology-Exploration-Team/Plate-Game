using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    public InputActionAsset controls;
    [SerializeField] float SPEED = 0.1f;
    bool holdMoveRight = false;
    bool holdMoveLeft = false;
    private void Update()
    {
        if (holdMoveRight)
        {
            gameObject.transform.position += new Vector3(SPEED, 0);
        }

        if (holdMoveLeft)
        {
            gameObject.transform.position += new Vector3(-SPEED, 0);
        }
    }

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
}
