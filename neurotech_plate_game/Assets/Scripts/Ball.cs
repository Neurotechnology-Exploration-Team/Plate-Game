using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

/// <summary>
/// A ball that bounces off of the player block in a direction that changes based off where the 
/// ball hits the player relative to its center.
/// </summary>
public class Ball : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 1f;
    [SerializeField] private Collider2D col;
    private Vector3 velocity;
    private Vector3 direction;
    private Vector3 position;
    private float angle;
    private bool paused; // When we implement pausing this should be used
    #endregion

    #region Methods
    #region Internal Methods
    void Start()
    {
        paused = false;
        Invoke(nameof(SetRandomTrajectory), 1f);
        position = transform.position;
    }

    void Update()
    {
        if (!paused)
        {
            // Scale the velocity based on the deltaTime (time between current and last frame)
            velocity = direction * speed * Time.deltaTime;
            position += velocity;
            transform.position = position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject != player)
        {
            // Check which direction the ball hit from

            // the normal is the vector that is perpendicular to the side of the collider
            // that was hit, so if the top is hit then that will be the up vector.

            // This will immediately stop working if any thing is rotated
            Vector3 norm = collision.contacts[0].normal;
            if (norm == Vector3.up)
            {
                direction.y *= -1;
            }
            else if (norm == Vector3.down)
            {
                direction.y *= -1;
            }
            if (norm == Vector3.right)
            {
                direction.x *= -1;
            }
            else if (norm == Vector3.left)
            {
                direction.x *= -1;
            }
        }
    }
    #endregion

    #region External Methods
    /// <summary>
    /// Used to start the ball at a random position and trajectory towards the player.
    /// </summary>
    public void SetRandomTrajectory()
    {
        float randAngle = Random.Range(Mathf.PI + 1, 2 * Mathf.PI - 1);   
        direction = new Vector3(Mathf.Cos(randAngle), Mathf.Sin(randAngle));
    }

    /// <summary>
    /// Reads the normalized distance from the center of player and sends the ball in a direction
    /// away from the player with the angle of the direction equal to the arccos of the n-distance
    /// </summary>
    /// <param name="dist">The normalized horizontal distance from the center of the player</param>
    public void PlayerBounce(float dist)
    {
        // If the ball hits the side it will return a value greater than 1 or less than -1 because
        // the center of the ball is outside the horizontal extent of the player block. Reverse
        // x when this is the case otherwise it will throw a NaN for arccos(dist)
        if (dist >= 1 || dist <= -1)
        {
            direction.x *= -1f;
        }
        // Send the ball straight up if the distance is zero
        else if (dist == 0)
        {
            direction = Vector3.up;
        }
        // Sends the at an angle according to the balls horizontal distance from the center of the
        // player on impact
        else
        {
            Debug.Log(dist);
            angle = Mathf.Acos(dist);
            direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle));
        }
    }
    #endregion
    #endregion
}