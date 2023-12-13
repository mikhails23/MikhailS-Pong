using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PUFastPaddleController : MonoBehaviour
{
    public PowerUpManager manager;
    public PowerUpController controller;
    public Collider2D ball;


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision == ball) {
            Debug.Log("Fast Paddle Triggered");
            controller.ActivateTimedFastPaddle();
            manager.RemovePowerUp(gameObject);
        }
    }



}
