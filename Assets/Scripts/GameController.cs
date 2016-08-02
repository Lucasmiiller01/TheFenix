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
    [SerializeField]
    private SpawnCarController spawnCarController_l;
    [SerializeField]
    private SpawnCarController spawnCarController_r;
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

    void Update ()
    {
        if (instancePaper != null && created.Equals(true))
        {
            if(instancePaper.transform.position.x < 0f)
                instancePaper.transform.position = Vector2.Lerp(instancePaper.transform.position, new Vector2(0, 1), 0.1f);
            else
            {
                created = false;
            }
        }
        if (inGame)
        {
            Timer();
        }
        if (game.activeSelf.Equals(spawnCarController_l.enabled))
        {
            spawnCarController_l.enabled = !game.activeSelf;
            if(spawnCarController_l.enabled) spawnCarController_l.StartCoroutine(spawnCarController_l.CarSpawn());
            print("oi");
        }
        if (game.activeSelf.Equals(spawnCarController_r.enabled))
        {
            spawnCarController_r.enabled = !game.activeSelf;
            if (spawnCarController_r.enabled) spawnCarController_r.StartCoroutine(spawnCarController_r.CarSpawn());
        }
    }

    public void OnCreate()
    {
       instancePaper = (GameObject) Instantiate(paper, new Vector3(-20,1,0), paper.transform.rotation);
       instancePaper.transform.parent = game.transform;
       created = true;
    }
    public void DecreaseProps()
    {
        props -= new Vector3(1, 1, 1);
        if (props.x < 0) props.x = 0;
        if (props.y < 0) props.y = 0;
        if (props.z < 0) props.z= 0;
    }

    private void Timer()
    {
        seconds = Mathf.FloorToInt(Time.fixedTime);
        minutes = Mathf.FloorToInt(seconds / 60);
        seconds = seconds - (60 * minutes);
    }
}
