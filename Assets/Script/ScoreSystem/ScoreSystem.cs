using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public Timer timer;
    public int stars;

    public void CalculateScore()
    {
        timer.StopTimer();
        float elapsedTime = timer.GetElapsedTime();

        if (elapsedTime <= 60)
        {
            stars = 3; // 1 minute or less
        }
        else if (elapsedTime <= 120)
        {
            stars = 2; // 2 minutes or less
        }
        else if (elapsedTime <= 180)
        {
            stars = 1; // 3 minutes or less
        }
        else
        {
            stars = 0; // More than 3 minutes
        }

        DisplayScore();
    }

    void DisplayScore()
    {
        Debug.Log("Stars: " + stars);
    }
}
