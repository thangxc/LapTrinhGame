using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : Singleton<Timer>
{
    public TextMeshProUGUI timerText;
    private float startTime;
    private bool isRunning;

    void Update()
    {
        if (isRunning)
        {
            float t = Time.time - startTime;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");
            timerText.text = minutes + ":" + seconds;
        }
    }

    public void StartTimer()
    {
        startTime = Time.time;
        isRunning = true;
    }

    public void StopTimer()
    {
        print("StopTime");
        isRunning = false;
    }

    public float GetElapsedTime()
    {
        return Time.time - startTime;
    }
}
