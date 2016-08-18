﻿using UnityEngine;
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
            if(instancePaper.transform.localPosition.x < paper.transform.position.x)
                instancePaper.transform.localPosition = Vector2.Lerp(instancePaper.transform.localPosition, new Vector2(paper.transform.position.x, paper.transform.position.y), 0.1f);
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
       instancePaper = (GameObject) Instantiate(paper);
       instancePaper.transform.parent = game.transform;
       instancePaper.transform.localPosition = new Vector3(-20, paper.transform.position.y, 0);
        created = true;
    }
    public void UpFeedBack()
    {
        if(Selector.auxProps.x != 0)
        {
            GameObject instanceMessage;
            instanceMessage = (GameObject)Instantiate(message, stats[0].transform.position, stats[0].transform.rotation);
            instanceMessage.GetComponent<RectTransform>().SetParent(canvas.GetComponent<RectTransform>(), false);
            instanceMessage.transform.position = new Vector2(stats[0].transform.position.x +1, stats[0].transform.position.y);
            instanceMessage.GetComponent<Text>().color = Color.green;
            instanceMessage.GetComponent<Text>().text = "+" + Selector.auxProps.x * 10 + "%";
        }
        if (Selector.auxProps.y != 0)
        {
            GameObject instanceMessage;
            instanceMessage = (GameObject)Instantiate(message, stats[1].transform.position, stats[1].transform.rotation);
            instanceMessage.GetComponent<RectTransform>().SetParent(canvas.GetComponent<RectTransform>(), false);
            instanceMessage.transform.position = new Vector2(stats[1].transform.position.x +1, stats[1].transform.position.y);
            instanceMessage.GetComponent<Text>().color = Color.green;
            instanceMessage.GetComponent<Text>().text = "+" + Selector.auxProps.y * 10 + "%";
        }
        if (Selector.auxProps.z != 0)
        {
            GameObject instanceMessage;
            instanceMessage = (GameObject)Instantiate(message, stats[2].transform.position, stats[2].transform.rotation);
            instanceMessage.GetComponent<RectTransform>().SetParent(canvas.GetComponent<RectTransform>(), false);
            instanceMessage.transform.position = new Vector2(stats[2].transform.position.x +1, stats[2].transform.position.y);
            instanceMessage.GetComponent<Text>().color = Color.green;
            instanceMessage.GetComponent<Text>().text = "+" + Selector.auxProps.z * 10 + "%";
        }
    }
    void DecreaseFeedBack()
    {
        for (int i = 0; i < stats.Length; i++)
        {
            GameObject instanceMessage;
            instanceMessage = (GameObject)Instantiate(message, stats[i].transform.position, stats[i].transform.rotation);
            instanceMessage.GetComponent<RectTransform>().SetParent(canvas.GetComponent<RectTransform>(), false);
            instanceMessage.transform.position = new Vector2(stats[i].transform.position.x +1, stats[i].transform.position.y);
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
            if (stats[0] != null) stats[0].GetComponent<Text>().text = props.x * 10 + "%";
            if (stats[1] != null) stats[1].GetComponent<Text>().text = props.y * 10 + "%";
            if (stats[2] != null) stats[2].GetComponent<Text>().text = props.z * 10 + "%";
            checkProps = false;
        }
    }
}
