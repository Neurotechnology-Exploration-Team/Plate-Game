using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D Rigidbody;
    public float speed = 500f;


    // Start is called before the first frame update
    void Start()
    {
        this.Rigidbody = GetComponent<Rigidbody2D>();
        Invoke(nameof(SetRandomTrajectory), 1f);
    }

    public void SetRandomTrajectory()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        this.Rigidbody.AddForce(force.normalized * this.speed);
    }
}
