using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using MyExtensions;

public class GameController : MonoBehaviour
{

    private Text clock;

    private int seconds;
    private int minutes;
    public bool inGame;
    public bool isPick;
    [SerializeField]
    private GameObject game;

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
        clock = GameObject.Find("Scene_Game/Canvas/Text").GetComponent<Text>();
        inGame = true;
        seconds = 0;
        minutes = 0;
        InvokeRepeating("DecreaseProps", 10f, 10f);
        //dayActual = 1;
    }

	void Update ()
    {

        if (inGame)
        {
            Time_();
        }

    }

    public void OnCreate()
    {
       GameObject gameObject = (GameObject) Instantiate(paper);
       gameObject.transform.parent = game.transform;
    }
    public void Game(bool active)
    {
       if(active)
            clock = GameObject.Find("Scene_Game/Canvas/Text").GetComponent<Text>();
        else
            clock = GameObject.Find("Scene_City/Canvas/Text").GetComponent<Text>();

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
