using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public PaddleController leftPaddleController;
    public PaddleController rightPaddleController;

    public GameObject leftPaddle;
    public GameObject rightPaddle;
    
    public float magnitude;
    public float powerUpDuration;

    private bool isFastPaddleOn;
    private Coroutine fastPaddleCoroutine;

    private bool isLongPaddleOn;
    private Coroutine longPaddleCoroutine;

    void Start()
    {
        isFastPaddleOn = false;
        fastPaddleCoroutine = null;
    }

    void Update()
    {
        // "Cheat" button for paddle power up
        // if (Input.GetKey(KeyCode.T)) {
        //     ActivateTimedFastPaddle();
        // }
        // if (Input.GetKey(KeyCode.Y)) {
        //     ActivateTimedLongPaddle();
        // }
    }

    public void ActivateTimedFastPaddle() {
        // If there's ongoing Fast Paddle power up, restart coroutine to restart duration
        if (isFastPaddleOn) {
            Debug.Log("Second Fast Paddle triggered, stop existing power up");
            StopCoroutine(fastPaddleCoroutine);
            DeactivateFastPaddlePowerUp();
            isFastPaddleOn = false;
        }

        Debug.Log("Start Fast Paddle Coroutine");
        fastPaddleCoroutine = StartCoroutine(FastPaddleCoroutine());
    }

    private void ActivateFastPaddlePowerUp() {
        leftPaddleController.ActivateFastPaddlePowerUp(magnitude);
        rightPaddleController.ActivateFastPaddlePowerUp(magnitude);
    }
    
    private void DeactivateFastPaddlePowerUp() {
        leftPaddleController.DeactivateFastPaddlePowerUp(magnitude);
        rightPaddleController.DeactivateFastPaddlePowerUp(magnitude);
    }

    private IEnumerator FastPaddleCoroutine() {
        Debug.Log("Fast Paddle Coroutine started");
        isFastPaddleOn = true;
        ActivateFastPaddlePowerUp();
        yield return new WaitForSeconds(powerUpDuration);
        Debug.Log("Fast Paddle Expired");
        DeactivateFastPaddlePowerUp();
        isFastPaddleOn = false;
    }

    public void ActivateTimedLongPaddle() {
        // If there's ongoing Long Paddle power up, restart coroutine to restart duration
        if (isLongPaddleOn) {
            Debug.Log("Second Long Paddle triggered, stop existing power up");
            StopCoroutine(longPaddleCoroutine);
            DeactivateLongPaddlePowerUp();
            isLongPaddleOn = false;
        }

        Debug.Log("Start Long Paddle Coroutine");
        longPaddleCoroutine = StartCoroutine(LongPaddleCoroutine());
    }

    private void ActivateLongPaddlePowerUp() {
        leftPaddle.transform.localScale = new Vector3(
            leftPaddle.transform.localScale.x,
            leftPaddle.transform.localScale.y * magnitude,
            leftPaddle.transform.localScale.z);
        rightPaddle.transform.localScale = new Vector3(
            rightPaddle.transform.localScale.x,
            rightPaddle.transform.localScale.y * magnitude,
            rightPaddle.transform.localScale.z);
    }
    
    private void DeactivateLongPaddlePowerUp() {
        leftPaddle.transform.localScale = new Vector3(
            leftPaddle.transform.localScale.x,
            leftPaddle.transform.localScale.y / magnitude,
            leftPaddle.transform.localScale.z);
        rightPaddle.transform.localScale = new Vector3(
            rightPaddle.transform.localScale.x,
            rightPaddle.transform.localScale.y / magnitude,
            rightPaddle.transform.localScale.z);
    }

    private IEnumerator LongPaddleCoroutine() {
        Debug.Log("Long Paddle Coroutine started");
        isLongPaddleOn = true;
        ActivateLongPaddlePowerUp();
        yield return new WaitForSeconds(powerUpDuration);
        Debug.Log("Long Paddle Expired");
        DeactivateLongPaddlePowerUp();
        isLongPaddleOn = false;
    }

}
