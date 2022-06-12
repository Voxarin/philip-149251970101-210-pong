using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed;

    public KeyCode upKey;
    public KeyCode downKey;
    private Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MoveObject(GetInput());
    }

    private Vector2 GetInput()
    {
        if (Input.GetKey(upKey))
        {
            return Vector2.up * speed;
        }
        else if (Input.GetKey(downKey))
        {
            return Vector2.down * speed;
        }

        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        rig.velocity = movement;
    }
}

/*
//old
public class PaddleController : MonoBehaviour
{
    public int speed;

    private void Start()
    {
    }

    private void Update()
    {
        Vector3 movement = Vector3.zero;

        // get input 
        if (Input.GetKey(KeyCode.W))
        {
            movement = Vector3.up * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement = Vector3.down * speed;
        }

        // move object
        transform.Translate(movement * Time.deltaTime);
    }
}
*/
