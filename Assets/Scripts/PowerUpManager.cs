using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public Transform spawnArea;
    public int maxPowerUpAmount;
    
    public int spawnInterval;
    public int maxTimeToLive;

    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax;

    public List<GameObject> powerUpTemplateList;
    private List<TimedPowerUp> powerUpList;

    private float timer;

    private void Start() {
        powerUpList = new List<TimedPowerUp>();
        timer = 0;
    }

    private void Update() {
        timer += Time.deltaTime;

        if (timer > spawnInterval) {
            GenerateRandomPowerUp();
            timer -= spawnInterval;
        }

        foreach (TimedPowerUp timedPowerUp in powerUpList.ToList()) {
            float ttl = timedPowerUp.powerUpTimer;
            // Debug.Log("ttl: " + ttl);
            timedPowerUp.powerUpTimer = ttl += Time.deltaTime;
            if (ttl > maxTimeToLive) {
                RemoveTimedPowerUp(timedPowerUp);
            }
        }
        
    }

    public void GenerateRandomPowerUp() {
        GenerateRandomPowerUp(new Vector2(
            Random.Range(powerUpAreaMin.x, powerUpAreaMax.x),
            Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)
        ));
    }

    public void GenerateRandomPowerUp(Vector2 position) {
        // Debug.Log("GenerateRandomPowerUp");
        if (powerUpList.Count >= maxPowerUpAmount) {
            return;
        }

        if (position.x < powerUpAreaMin.x ||
            position.x > powerUpAreaMax.x ||
            position.y < powerUpAreaMin.y ||
            position.y > powerUpAreaMax.y
        ) {
            return;
        }
        
        int randomIndex = Random.Range(0, powerUpTemplateList.Count);

        GameObject powerUp = Instantiate(
            powerUpTemplateList[randomIndex], 
            new Vector3(position.x, position.y, powerUpTemplateList[randomIndex].transform.position.z), 
            Quaternion.identity, 
            spawnArea);
        powerUp.SetActive(true);

        powerUpList.Add(new TimedPowerUp(powerUp));
        // Debug.Log("Generated");
    }

    public void RemovePowerUp(GameObject powerUp) {
        TimedPowerUp timedPowerUp = SearchInList(powerUp);
        if (timedPowerUp != null) {
            powerUpList.Remove(timedPowerUp);
            Destroy(timedPowerUp.powerUpObject);
            // Debug.Log("Power up removed");
        }
    }

    private void RemoveTimedPowerUp(TimedPowerUp timedPowerUp) {
        powerUpList.Remove(timedPowerUp);
        Destroy(timedPowerUp.powerUpObject);
        // Debug.Log("Timed Power up removed");
    }

    public void RemoveAllPowerUp() {
        foreach (TimedPowerUp powerUpItem in powerUpList) {
            RemovePowerUp(powerUpItem.powerUpObject);
        }
    }

    private TimedPowerUp SearchInList(GameObject powerUp) {
        foreach (TimedPowerUp item in powerUpList) {
            if (GameObject.ReferenceEquals(item.powerUpObject, powerUp)) {
                return item;
            }
        }

        return null;
    }

    private class TimedPowerUp {
        public GameObject powerUpObject;
        public float powerUpTimer;

        public TimedPowerUp(GameObject powerUp) {
            this.powerUpObject = powerUp;
            this.powerUpTimer = 0;
        }

    }
}
