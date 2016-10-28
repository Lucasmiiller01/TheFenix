using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    private int seconds;
    private int[,] papersOrder;
    private int myOrder;
    private int actualPaper;
    private int minutes;
    private bool inGame;
    public bool isPick;
    public bool created;
    [SerializeField]
    private GameObject game;
    [SerializeField]
    private GameObject iCamera;
    [SerializeField]
    private Transform canvas;
    [SerializeField]
    private GameObject message;
    [SerializeField]
    private GameObject[] go;
    private GameObject instancePaper;

    [SerializeField]
    private GameObject paper;
    [SerializeField]
    private GameObject[] stats = new GameObject[3];
    [SerializeField]
    private PropsController[] propsController;
    public Vector3 props;
    public bool checkProps;
    public bool FinaleDay;
    [SerializeField]
    private SpriteRenderer backGround;
    [SerializeField]
    private SpriteRenderer[] clouds;
    [SerializeField]
    private Vector3[] preValues = new Vector3[3];
    [SerializeField]
    private GameObject ballon;
    public Color color;
    public Color nColor;
    public bool fade;
    private int Etapa;
    public bool updateProps;


    void Start()
    {
        papersOrder = new int[4, 5];
        papersOrder[0, 0] = 0; papersOrder[0, 1] = 1; papersOrder[0, 2] = 2; papersOrder[0, 3] = 3; papersOrder[0, 4] = 4;
        papersOrder[1, 0] = 3; papersOrder[1, 1] = 2; papersOrder[1, 2] = 0; papersOrder[1, 3] = 1; papersOrder[1, 4] = 4;
        papersOrder[2, 0] = 4; papersOrder[2, 1] = 0; papersOrder[2, 2] = 1; papersOrder[2, 3] = 2; papersOrder[2, 4] = 3;
        papersOrder[3, 0] = 2; papersOrder[3, 1] = 3; papersOrder[3, 2] = 4; papersOrder[3, 3] = 0; papersOrder[3, 4] = 1;
        myOrder = Random.Range(0, 4);
        actualPaper = 0;
        fade = false;
        checkProps = true;
        inGame = true;
        //InvokeRepeating("DecreaseProps", 10f, 10f);
        //InvokeRepeating("DecreasePropsFeedBack", 3f, 2f);
        
        FinaleDay = false;
        if (Tutorial.inTuto) Etapa = 0;
        else
        {
            Etapa = 1;
            go[3].SetActive(true);
            go[2].SetActive(true);
            go[1].SetActive(false);
            go[0].SetActive(false);
        }
        updateProps = false;

    }
    public void NewProps()
    {
        props = preValues[Random.Range(0, 3)];

    }
    public int GetEtapa() {
        return Etapa;

    }
    public int SetEtapa(int value)
    {
        return Etapa += value;
    }

    void Update ()
    {
        if (Etapa > 0 && !updateProps)
        {
            NewProps();
            updateProps = true;
        }
        else if(!updateProps)
        {
            props = preValues[3];
            updateProps = true;
        }
        if (!FinaleDay && !fade)
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
            if (checkProps) UpdateText();
        }
    }
  
    public void OnCreate()
    {
        if (actualPaper < 3)
        {
            instancePaper = (GameObject)Instantiate(paper);
            instancePaper.transform.parent = game.transform;
            instancePaper.transform.localPosition = new Vector3(-20, paper.transform.position.y, 0);
            instancePaper.GetComponent<PaperController>().SetValue(papersOrder[myOrder, actualPaper]);
            actualPaper++;
            created = true;
        }
        else
        {
            ballon.SetActive(true);
            Camera.main.GetComponent<Animator>().SetBool("back", false);
        }
    }
   /* public void UpFeedBack()
    {
        if (!FinaleDay && !fade)
        {
            if (Selector.auxProps.x != 0)
            {
                GameObject instanceMessage;
                instanceMessage = (GameObject)Instantiate(message, stats[0].transform.position, stats[0].transform.rotation);
                instanceMessage.GetComponent<RectTransform>().SetParent(canvas.GetComponent<RectTransform>(), false);
                instanceMessage.transform.position = new Vector2(stats[0].transform.position.x +1, stats[0].transform.position.y);
                instanceMessage.GetComponent<Text>().color = Color.green;
                instanceMessage.GetComponent<Text>().text = "+" + Selector.auxProps.x + "%";
            }
            if (Selector.auxProps.y != 0)
            {
                GameObject instanceMessage;
                instanceMessage = (GameObject)Instantiate(message, stats[1].transform.position, stats[1].transform.rotation);
                instanceMessage.GetComponent<RectTransform>().SetParent(canvas.GetComponent<RectTransform>(), false);
                instanceMessage.transform.position = new Vector2(stats[1].transform.position.x +1, stats[1].transform.position.y);
                instanceMessage.GetComponent<Text>().color = Color.green;
                instanceMessage.GetComponent<Text>().text = "+" + Selector.auxProps.y + "%";
            }
            if (Selector.auxProps.z != 0)
            {
                GameObject instanceMessage;
                instanceMessage = (GameObject)Instantiate(message, stats[2].transform.position, stats[2].transform.rotation);
                instanceMessage.GetComponent<RectTransform>().SetParent(canvas.GetComponent<RectTransform>(), false);
                instanceMessage.transform.position = new Vector2(stats[2].transform.position.x +1, stats[2].transform.position.y);
                instanceMessage.GetComponent<Text>().color = Color.green;
                instanceMessage.GetComponent<Text>().text = "+" + Selector.auxProps.z + "%";
            }
        }
    }
    void DecreaseFeedBack()
    {
        if (!FinaleDay && !fade)
        {
             for (int i = 0; i < stats.Length; i++)
            {
                GameObject instanceMessage;
                instanceMessage = (GameObject)Instantiate(message, stats[i].transform.position, stats[i].transform.rotation);
                instanceMessage.GetComponent<RectTransform>().SetParent(canvas.GetComponent<RectTransform>(), false);
                instanceMessage.transform.position = new Vector2(stats[i].transform.position.x +1, stats[i].transform.position.y);
            }
        }
    }*/
    void DecreasePropsFeedBack()
    {
        if (!FinaleDay && !fade)
        {
            GameObject instanceMessage;
            if (propsController[0] != null && propsController[0].decreaseValue != 0)
            {
                instanceMessage = (GameObject) Instantiate(message, new Vector3(350, 500, 0), message.transform.rotation);
                props -= new Vector3(propsController[0].decreaseValue, 0, 0);
                instanceMessage.GetComponent<Text>().text = "-" + (propsController[0].decreaseValue).ToString()  + "%";
                instanceMessage.GetComponent<RectTransform>().SetParent(canvas.GetComponent<RectTransform>(), false);
                checkProps = true;
            }
            if (propsController[1] != null && propsController[1].decreaseValue != 0)
            {
                instanceMessage = (GameObject) Instantiate(message, new Vector3(570, 500, 0), message.transform.rotation);
                props -= new Vector3(0, propsController[1].decreaseValue, 0);
                instanceMessage.GetComponent<Text>().text = "-" + (propsController[1].decreaseValue).ToString() + "%";
                instanceMessage.GetComponent<RectTransform>().SetParent(canvas.GetComponent<RectTransform>(), false);
                checkProps = true;
            }
            if (propsController[2] != null && propsController[2].decreaseValue != 0)
            {
                instanceMessage = (GameObject) Instantiate(message, new Vector3(120, 500, 0), message.transform.rotation);
                props -= new Vector3(0, 0, propsController[2].decreaseValue);
                instanceMessage.GetComponent<Text>().text = "-" + (propsController[2].decreaseValue).ToString() + "%";
                instanceMessage.GetComponent<RectTransform>().SetParent(canvas.GetComponent<RectTransform>(), false);
                checkProps = true;
            }
        }

    }
    public void DecreaseProps()
    {
        if (!FinaleDay && !fade)
        {
            props -= new Vector3(10, 10, 10);
            if (!checkProps) checkProps = true;
        }

    }
    
    private void Timer()
    {
        seconds = Mathf.FloorToInt(Time.fixedTime);
        minutes = Mathf.FloorToInt(seconds / 60);
        seconds = seconds - (60 * minutes);
    }
    private void UpdateText()
    {
        if (!FinaleDay && !fade)
        {
            if (props.x > 100) props.x = 100;
            else if (props.x < 0) props.x = 0;
            if (props.y > 100) props.y = 100;
            else if(props.y < 0) props.y = 0;
            if (props.z > 100) props.z = 100;
            else if(props.z < 0) props.z = 0;
            if (checkProps)
            {
                if (stats[0] != null) stats[0].GetComponent<Text>().text = props.x + "%";
                if (stats[1] != null) stats[1].GetComponent<Text>().text = props.y + "%";
                if (stats[2] != null) stats[2].GetComponent<Text>().text = props.z + "%";
                checkProps = false;
            }
         }
    }
}
