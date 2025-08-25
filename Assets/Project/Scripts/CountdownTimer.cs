using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;


public class CountdownTimer : MonoBehaviour
{

    private float currentTime = 0f;
    [SerializeField]
    private float startingTime = 0f;
    [SerializeField]
    private Text countdownTimerText;
    private Color color = new Color(1, 1, 1, 1);


    [SerializeField]
    private GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        StartCounting();
    }

    void StartCounting()
    {
        currentTime -= Time.deltaTime;
        currentTime = Mathf.Clamp(currentTime, 0f, Mathf.Infinity);
        countdownTimerText.text = DisplayTime(currentTime);
        countdownTimerText.color = color;

        if (currentTime <= 10)
        {
            color = new Color(255, 0, 0, 1);
            if (currentTime <= 0)
            {
                currentTime = 0;

                StartCoroutine(GameOver());
            }
        }

    }
 private string DisplayTime(float timeToDisplay)
        {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private IEnumerator GameOver()
    {
        gameOverPanel.SetActive(true);
        yield return new WaitForSeconds(2);
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(0);
    }

}
