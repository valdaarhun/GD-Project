using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private float startHour = 12f;
    private float sunriseHour = 7f;
    private float sunsetHour = 19f;
    private TimeSpan sunriseTime;
    private TimeSpan sunsetTime;
    private DateTime currentTime;

    public void retry()
    {
        Health.currentHealth = 100;
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(startHour);
        sunriseTime = TimeSpan.FromHours(sunriseHour);
        sunsetTime = TimeSpan.FromHours(sunsetHour);
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void quit()
    {
        Application.Quit();
    }
}
