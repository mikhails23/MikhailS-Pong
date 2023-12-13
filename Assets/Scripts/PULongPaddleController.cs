using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PULongPaddleController : MonoBehaviour
{
    public PowerUpManager manager;
    public PowerUpController controller;
    public Collider2D ball;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision == ball) {
            Debug.Log("Activate Long Paddle");
            controller.ActivateTimedLongPaddle();
            manager.RemovePowerUp(gameObject);
        }
    }
}
