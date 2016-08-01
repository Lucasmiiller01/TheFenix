using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    private int seconds;
    private int minutes;
    private bool inGame;
    public bool isPick;
    public bool created;
    [SerializeField]
    private GameObject game;
    private GameObject instancePaper;

    [SerializeField]
    private GameObject paper;
    public Vector3 props;

    void Start()
    {
        inGame = true;
        InvokeRepeating("DecreaseProps", 10f, 10f);
        props = new Vector3(Random.Range(5, 9), Random.Range(5, 9), Random.Range(5, 9));
    }

    void FixedUpdate()
    {

        if (inGame)
        {
            Timer();
        }
    }
	void Update ()
    {
        if (instancePaper != null && created.Equals(true))
        {
            if(instancePaper.transform.position.x < 0.5f)
                instancePaper.transform.position += new Vector3(0.1f,0,0);
            else
            {
                created = false;
            }
        }
    }

    public void OnCreate()
    {
       instancePaper = (GameObject) Instantiate(paper, new Vector3(-3,0,0), paper.transform.rotation);
       instancePaper.transform.parent = game.transform;
       created = true;
    }
    public void DecreaseProps()
    {
        props -= new Vector3(1, 1, 1);
    }

    private void Timer()
    {
        seconds = Mathf.FloorToInt(Time.fixedTime);
        minutes = Mathf.FloorToInt(seconds / 60);
        seconds = seconds - (60 * minutes);
    }
}
