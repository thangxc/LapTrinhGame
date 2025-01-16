using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : Singleton<ScoreSystem>
{
    public List<int> starsTarget;
    [HideInInspector]
    public int stars;

    public TextMeshProUGUI scoreText;

    public void CalculateScore()
    {
        Timer.Instance.StopTimer();
        float elapsedTime = Timer.Instance.GetElapsedTime();

        if (elapsedTime <= starsTarget[0])
        {
            stars = 3; // 1 minute or less
        }
        else if (elapsedTime <= starsTarget[1])
        {
            stars = 2; // 2 minutes or less
        }
        else if (elapsedTime <= starsTarget[2])
        {
            stars = 1; // 3 minutes or less
        }
        else
        {
            stars = 0; // More than 3 minutes
        }

        DisplayScore(elapsedTime);
        UpdateStars(stars);
    }

    void DisplayScore(float elapsedTime)
    {

        float maxScore = 1000f;   // Maximum possible score
        float timeFactor = 5f;   // Controls the rate of score decay

        // Calculate the score
        float score = maxScore / (1 + elapsedTime / timeFactor);
        int scoreInt = Mathf.FloorToInt(score);
        scoreText.text = scoreInt.ToString("D4");
        Debug.Log("Stars: " + stars);
    }


    public Image[] starsImage; // Array to hold the star images (assign them in the Inspector)
    public Sprite fullStarSprite; // The sprite for a full star
    public Sprite emptyStarSprite; // The sprite for an empty star

    void UpdateStars(int count)
    {
        for (int i = 0; i < starsImage.Length; i++)
        {
            if (i < count)
            {
                // Set to full star
                starsImage[i].sprite = fullStarSprite;
            }
            else
            {
                // Set to empty star
                starsImage[i].sprite = emptyStarSprite;
            }
        }
    }
}
