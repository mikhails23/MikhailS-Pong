using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreKiri;
    public TextMeshProUGUI scoreKanan;

    public ScoreManager scoreManager;

    private void Update()
    {
        scoreKiri.text = scoreManager.leftScore.ToString();
        scoreKanan.text = scoreManager.rightScore.ToString();

        // scoreKiri.text = $"{scoreManager.leftScore}";
        // scoreKanan.text = $"{scoreManager.rightScore}";
    }
}
