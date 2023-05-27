using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScoring : MonoBehaviour
{
    public TextMeshProUGUI  timerText;
    private float startTime;
    private bool timerIsRunning = false;
    private float elapsedTime = 0f;
    private float addTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize timer text
        timerText.text = "00:00";

        // // Load previous timer value if available
        // if (PlayerPrefs.HasKey("Timer"))
        // {
        //     elapsedTime = PlayerPrefs.GetFloat("Timer");
        //     DisplayTime(elapsedTime);
        // }

        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            // if(addTime == true){
            //     elapsedTime += 60f;
            //     addTime = false;
            // }
            Debug.Log(Time.time);
            Debug.Log(startTime);
            elapsedTime = Time.time - startTime + addTime;
            DisplayTime(elapsedTime);
            Debug.Log(elapsedTime);
        }
    }

    // Start the timer
    public void StartTimer()
    {
        startTime = Time.time;
        timerIsRunning = true;
    }

    // Stop the timer and save the elapsed time
    public void StopTimer()
    {
        Debug.Log("clickkkedd");
        timerIsRunning = false;
        PlayerPrefs.SetFloat("Timer", elapsedTime);
        PlayerPrefs.Save();
    }

    // Add 60 seconds to the timer
    public void AddTime()
    {

        Debug.Log("clickkkedd");
        // timerIsRunning = false;
        // elapsedTime += 60f;
        // Debug.Log(elapsedTime);
        // DisplayTime(elapsedTime);
        // StartTimer();
          addTime += 60.0f;

    }

    // Display time in minutes and seconds
    void DisplayTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60f);
        float seconds = Mathf.FloorToInt(time % 60f);
        //Debug.Log(time.ToString("F2"));
        //Debug.Log(string.Format("{0:00}:{1:00}", minutes, seconds));
        timerText.SetText(string.Format("{0:00}:{1:00}", minutes, seconds));
    }
}