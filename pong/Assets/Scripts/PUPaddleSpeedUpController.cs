using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPaddleSpeedUpController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public float speedMultiplier;

    public float duration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            manager.ActivatePUPadSpeedUp(speedMultiplier, duration);
            manager.RemovePowerUp(gameObject);
        }
    }
}
