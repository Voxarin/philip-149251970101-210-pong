using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PaddleController : MonoBehaviour
{
    public int speed;

    public KeyCode upKey;
    public KeyCode downKey;
    private Rigidbody2D rig;
    internal float speedUp = 1;

    public PowerUpManager manager;

    internal Dictionary<PUType, float> PUDurations = new Dictionary<PUType, float>();

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MoveObject(GetInput());

        Dictionary<PUType, float> dictCopy = PUDurations.ToDictionary(x => x.Key, x => x.Value);

        foreach (var durCounter in dictCopy)
        {
            PUDurations[durCounter.Key] -= Time.deltaTime;

            if (PUDurations[durCounter.Key] <= 0)
            {
                if (durCounter.Key == PUType.padSpeedUp)
                {
                    manager.DeactivatePUPadSpeedUp(this);
                }
                else
                {
                    manager.DeactivatePUPadSizeUp(this);
                }
            }
        }
    }

    private Vector2 GetInput()
    {
        if (Input.GetKey(upKey))
        {
            return Vector2.up * speed * speedUp;
        }
        else if (Input.GetKey(downKey))
        {
            return Vector2.down * speed * speedUp;
        }

        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        rig.velocity = movement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BallController ballCheck = collision.gameObject.GetComponent<BallController>();

        if (ballCheck != null)
        {
            manager.lastTouchedPad = this;
        }
    }
}