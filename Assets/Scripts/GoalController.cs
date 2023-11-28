using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    public Collider2D ball;
    public bool isLeftTrigger;
    public bool isRightTrigger;
    public ScoreManager scoreManager;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision == ball) {
            if (isLeftTrigger) {
                scoreManager.AddRightScore(1);
            } else if (isRightTrigger) {
                scoreManager.AddLeftScore(1);
            }
        }
    }
}
