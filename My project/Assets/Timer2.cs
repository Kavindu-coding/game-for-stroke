using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer2 : MonoBehaviour
{
    // Start is called before the first frame update
    float currentTime1 = 0f;
    public float startingTime1 = 10f;
    public Text countDownText1;
    public GameObject gameOverPanel1;

    void Start()
    {
        currentTime1 = startingTime1;
        //gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime1 -= 1 * Time.deltaTime;
        countDownText1.text = " Remaining Time :" + currentTime1.ToString("0");

        if (currentTime1 <= 0)
        {
            currentTime1 = 0;
            //  timeAudio.Play();
            gameOverPanel1.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
