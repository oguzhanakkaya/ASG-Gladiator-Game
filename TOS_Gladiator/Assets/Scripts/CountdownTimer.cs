using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public Image TimerImage;
    public float floattime, totaltime = 15;
    public int  time;
    public Text  TimerText;
    public AudioSource CountdownAudio;


    void Start()
    {
        // TimerImage = GameObject.Find("Timer").GetComponent<Image>();
        //  TimerText = GameObject.Find("TimerText").GetComponent<Text>();
        CountdownAudio = GameObject.Find("CountdownMusic").GetComponent<AudioSource>();
        time = 15;

    }

   
    void Update()
    {
        
    }
    public void SetTimerToFullTime()
    {
        floattime = totaltime;
    }
    public void CountTimer()
    {
        floattime -= Time.deltaTime;
        time = (int)floattime;
        TimerText.text = time.ToString();
        TimerImage.fillAmount = (1 / totaltime) * floattime;

       
        if (time==6f)
        {
            CountdownAudio.Play();

        }

    }
    public void DeactiveTimer()
    {
        
        TimerImage.gameObject.SetActive(false);
        
    }
    public void ActiveTimer()
    {
        TimerImage.gameObject.SetActive(true);
    }
}
