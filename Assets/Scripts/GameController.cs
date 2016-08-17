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
    private Transform canvas;
    [SerializeField]
    private GameObject message;

    [SerializeField]
    private SpawnCarController spawnCarController_l;
    [SerializeField]
    private SpawnCarController spawnCarController_r;
    private GameObject instancePaper;

    [SerializeField]
    private GameObject paper;
    [SerializeField]
    private GameObject[] stats = new GameObject[3];
    public Vector3 props;
    public bool checkProps;

    void Start()
    {
        checkProps = true;
        inGame = true;
        InvokeRepeating("DecreaseProps", 10f, 10f);
        props = new Vector3(Random.Range(5, 9), Random.Range(5, 9), Random.Range(5, 9));
    }

    void Update ()
    {

        if (instancePaper != null && created.Equals(true))
        {
            if(instancePaper.transform.position.x < 1f)
                instancePaper.transform.position = Vector2.Lerp(instancePaper.transform.position, new Vector2(1, -1.5f), 0.1f);
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
        if (checkProps) UpdateText();
    }

    public void OnCreate()
    {
       instancePaper = (GameObject) Instantiate(paper, new Vector3(-20, paper.transform.position.y, 0), paper.transform.rotation);
       instancePaper.transform.parent = game.transform;
       created = true;
    }
    public void UpFeedBack()
    {
        for (int i = 0; i < stats.Length; i++)
        {
            GameObject instanceMessage;
            instanceMessage = (GameObject)Instantiate(message, new Vector3(stats[i].transform.position.x, i * 20, stats[i].transform.position.z), stats[i].transform.rotation);
            instanceMessage.GetComponent<RectTransform>().SetParent(canvas.GetComponent<RectTransform>(), false);
            instanceMessage.GetComponent<Text>().color = Color.green;
            if (i.Equals(0) && Selector.auxProps.x != 0) instanceMessage.GetComponent<Text>().text = "+" + Selector.auxProps.x.ToString();
            else if(i.Equals(0)) instanceMessage.GetComponent<Text>().text = "";
            if (i.Equals(1) && Selector.auxProps.y != 0) instanceMessage.GetComponent<Text>().text = "+" + Selector.auxProps.y.ToString();
            else if(i.Equals(1)) instanceMessage.GetComponent<Text>().text = "";
            if (i.Equals(2) && Selector.auxProps.z != 0) instanceMessage.GetComponent<Text>().text = "+" + Selector.auxProps.z.ToString();
            else if(i.Equals(2)) instanceMessage.GetComponent<Text>().text = "";
            print(i);

        }
    }
    void DecreaseFeedBack()
    {
        for (int i = 0; i < stats.Length; i++)
        {
            GameObject instanceMessage;
            instanceMessage = (GameObject)Instantiate(message, new Vector3(stats[i].transform.position.x, i * 20, stats[i].transform.position.z), stats[i].transform.rotation);
            instanceMessage.GetComponent<RectTransform>().SetParent(canvas.GetComponent<RectTransform>(), false);
        }
    }
    public void DecreaseProps()
    {
        props -= new Vector3(1, 1, 1);
        DecreaseFeedBack();
        if (!checkProps) checkProps = true;
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
    private void UpdateText()
    {
        if(checkProps)
        {
            if (stats[0] != null) stats[0].GetComponent<Text>().text = "Policia:" + props.z.ToString() + "/10";
            if (stats[1] != null) stats[1].GetComponent<Text>().text = "Hospital:" + props.x.ToString() + "/10";
            if (stats[2] != null) stats[2].GetComponent<Text>().text = "Escola:" + props.y.ToString() + "/10";
            checkProps = false;
        }
    }
}
