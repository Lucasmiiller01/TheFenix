using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using MyExtensions;

public class GameController : MonoBehaviour
{

    /*[SerializeField]
    private Text clock;
 

    private int seconds;
    private int minutes;
    private int randomSpawn;
    //public Vector3 props = new Vector3(1000,1000,1000);

    public bool inGame;
    [SerializeField]
    private int tempDay;
    //[SerializeField]
    //private Text day;

    private int dayActual;*/

    [SerializeField]
    private GameObject paper;

    void Start()
    {
        /*inGame = false;
        seconds = 0;
        minutes = 0;
        dayActual = 1;*/
    }

	void FixedUpdate ()
    {
        


    }
    public void OnCreate()
    {
       Instantiate(paper);
          
    }

    /*public void Time_()
    {
        if (inGame)
        {
            seconds = 240 + Mathf.FloorToInt(Time.fixedTime);
            minutes = Mathf.FloorToInt(seconds / 60);
            seconds = seconds - (60 * minutes);
            if (seconds< 10 && minutes< 10)
                clock.text = "0" + minutes + ":0" + seconds;
            else if (minutes< 10)
                clock.text = "0" + minutes + ":" + seconds;
            else if (seconds< 10)
                clock.text = minutes + ":0" + seconds;
            else
                clock.text = minutes + ":" + seconds;

          
          
        else
        {
                seconds = 240 + Mathf.FloorToInt(Time.fixedTime);
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
                //day.text = "Day " + dayActual.ToString();    

            }
        }
    }*/
    }
