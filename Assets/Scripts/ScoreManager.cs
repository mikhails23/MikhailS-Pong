using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int leftScore;
    public int rightScore;

    public int maxScore;

    public BallController ball;

    public void AddLeftScore(int increment) {
        leftScore += increment;

        ball.ResetBall();

        if (leftScore >= maxScore) {
            Debug.Log("Pemenangnya adalah Player Kiri");
            GameOver();
        }
    }

    public void AddRightScore(int increment) {
        rightScore += increment;

        ball.ResetBall();

        if (rightScore >= maxScore) {
            Debug.Log("Pemenangnya adalah Player Kanan");
            GameOver();
        }
    }

    public void GameOver() {
        SceneManager.LoadScene("Main Menu");
    }
    
}
