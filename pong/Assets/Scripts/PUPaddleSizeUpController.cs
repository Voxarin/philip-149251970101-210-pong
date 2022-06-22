using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPaddleSizeUpController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public float sizeMultiplier;

    public float duration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            manager.ActivatePUPadSizeUp(sizeMultiplier, duration);
            manager.RemovePowerUp(gameObject);
        }
    }
}
