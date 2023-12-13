using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed;
    public KeyCode upKey;
    public KeyCode downKey;
    private Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gerakan dari input
        MoveObject(GetInput());
    }

    private Vector2 GetInput() { 
        // Ambil input
        if (Input.GetKey(upKey)) {
            // Gerakan ke atas
            return Vector2.up * speed;
        }
        else if (Input.GetKey(downKey)) {
            // Gerakan ke bawah
            return Vector2.down * speed;            
        }

        // Ketika tidak ada input maka diam
        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement) {
        // Debug.Log("Paddle speed: " + movement);
        rig.velocity = movement;
    }

    public void ActivateFastPaddlePowerUp(float magnitude) {
        speed *= magnitude;       
    }

    public void DeactivateFastPaddlePowerUp(float magnitude) {
        speed /= magnitude;       
    }

}
