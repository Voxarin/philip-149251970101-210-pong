using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public Transform spawnArea;
    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax;

    public int maxPowerUpAmount;
    public int spawnInterval;

    public List<GameObject> powerUpTemplateList;
    private List<GameObject> powerUpList;

    private float timer;

    public BallController ball;
    public PaddleController leftPad;
    public PaddleController rightPad;
    public PaddleController lastTouchedPad;

    private void Start()
    {
        powerUpList = new List<GameObject>();
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnInterval)
        {
            GenerateRandomPowerUp();
            timer -= spawnInterval;
        }
    }

    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    }

    public void GenerateRandomPowerUp(Vector2 position)
    {
        if (powerUpList.Count >= maxPowerUpAmount)
        {
            return;
        }

        if (position.x < powerUpAreaMin.x || position.x > powerUpAreaMax.x ||
            position.y < powerUpAreaMin.y || position.y > powerUpAreaMax.y)
        {
            return;
        }

        int randomIndex = Random.Range(0, powerUpTemplateList.Count);

        GameObject powerUp = Instantiate(powerUpTemplateList[randomIndex], new Vector3(position.x, position.y, powerUpTemplateList[randomIndex].transform.position.z), powerUpTemplateList[randomIndex].transform.rotation, spawnArea);
        powerUp.SetActive(true);

        powerUpList.Add(powerUp);
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    public void RemoveAllPowerUp()
    {
        while (powerUpList.Count > 0)
        {
            RemovePowerUp(powerUpList[0]);
        }
    }
    public void ActivatePUSpeedUp(float magnitude)
    {
        ball.rig.velocity *= magnitude;
    }

    public void ActivatePUPadSpeedUp(float speedMultiplier, float duration)
    {
        lastTouchedPad.speedUp = speedMultiplier;

        if (lastTouchedPad.PUDurations.ContainsKey(PUType.padSpeedUp))
        {
            lastTouchedPad.PUDurations[PUType.padSpeedUp] = duration;
        }
        else
        {
            lastTouchedPad.PUDurations.Add(PUType.padSpeedUp, duration);
        }
    }

    public void ActivatePUPadSizeUp(float sizeMultiplier, float duration)
    {
        lastTouchedPad.transform.localScale = new Vector2(0.5f, lastTouchedPad.transform.localScale.y * sizeMultiplier);

        if (lastTouchedPad.PUDurations.ContainsKey(PUType.padSizeUp))
        {
            lastTouchedPad.PUDurations[PUType.padSizeUp] = duration;
        }
        else
        {
            lastTouchedPad.PUDurations.Add(PUType.padSizeUp, duration);
        }
    }

    public void DeactivatePUPadSpeedUp(PaddleController targetPad)
    {
        targetPad.speedUp = 1;
    }

    public void DeactivatePUPadSizeUp(PaddleController targetPad)
    {
        targetPad.transform.localScale = new Vector2(0.5f, 3f);
    }
}

public enum PUType
{
    padSpeedUp, padSizeUp
}
