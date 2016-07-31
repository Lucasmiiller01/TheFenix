using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using MyExtensions;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private Text clock;

    private int seconds;
    private int minutes;
    public bool inGame;
    public bool isPick;

    /*[SerializeField]
    private int tempDay;
    //[SerializeField]
    //private Text day;

    private int dayActual;*/

    [SerializeField]
    private GameObject paper;
    public Vector3 props = new Vector3(8, 8, 8);

    void Start()
    {
        inGame = true;
        seconds = 0;
        minutes = 0;
        InvokeRepeating("DecreaseProps", 10f, 10f);
        //dayActual = 1;
    }

	void FixedUpdate ()
    {

        if (inGame)
        {
            Time_();
        }

    }
    public void OnCreate()
    {
       Instantiate(paper);
          
    }
    public void DecreaseProps()
    {
        props -= new Vector3(1, 1, 1);
    }

    public void Time_()
    {
        seconds = Mathf.FloorToInt(Time.fixedTime);
        minutes = Mathf.FloorToInt(seconds / 60);
        seconds = seconds - (60 * minutes);
        if (seconds < 10 && minutes < 10)
            clock.text = "0" + minutes + ":0" + seconds;
        else if (minutes < 10)
            clock.text = "0" + minutes + ":" + seconds;
        else if (seconds < 10)
            clock.text = minutes + ":0" + seconds;
        else
            clock.text = minutes + ":" + seconds;
    }
}
