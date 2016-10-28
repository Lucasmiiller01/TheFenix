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

    static public int[] aswers;
    public Color color;
    public Color nColor;
    public bool fade;
    private int Etapa;
    public bool updateProps;


    void Start()
    {
        papersOrder = new int[4, 5];
        aswers = new int[3];
        papersOrder[0, 0] = 0; papersOrder[0, 1] = 1; papersOrder[0, 2] = 2; papersOrder[0, 3] = 3; papersOrder[0, 4] = 4;
        papersOrder[1, 0] = 3; papersOrder[1, 1] = 2; papersOrder[1, 2] = 0; papersOrder[1, 3] = 1; papersOrder[1, 4] = 4;
        papersOrder[2, 0] = 4; papersOrder[2, 1] = 0; papersOrder[2, 2] = 1; papersOrder[2, 3] = 2; papersOrder[2, 4] = 3;
        papersOrder[3, 0] = 2; papersOrder[3, 1] = 3; papersOrder[3, 2] = 4; papersOrder[3, 3] = 0; papersOrder[3, 4] = 1;
        myOrder = Random.Range(0, 4);
        actualPaper = 0;
        fade = false;
        checkProps = true;
        inGame = true;
        
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
        updateProps = false;
        return Etapa += value;

    }

    void Update ()
    {
        if (Etapa > 0 && !updateProps)
        {
            if(Etapa.Equals(2))
                props = preValues[4];
            else
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
            Camera.main.GetComponent<Animator>().SetBool("back", false);
            Invoke("Wait", 1);
            actualPaper = 0;
            myOrder = Random.Range(0, 4);
        }
    }
    void Wait()
    {
        ballon.SetActive(true);
    }

}
  
