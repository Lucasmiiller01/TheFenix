using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Selector : MonoBehaviour {

    private bool isSelect, onPaper;
    public static bool quit;

    [SerializeField]
    private bool aprove;
    [SerializeField]
    private string myType;
    [SerializeField]
    private BarController[] bars;
    [SerializeField]
    private TutorialFirst tutorial;

    private GameObject paper;
    private Vector3 mousePos;
    private Vector3 inicialPos;
    private int lifes;

    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private GameObject[] strols;
    public static Vector3 auxProps;
    public static float multCooldown;
    public static int actual;

    void Start ()
    {      
        inicialPos = this.transform.position;
        actual = 0;
        Resetao();
    }

    public void Resetao()
    {
        actual = 0;
        GameController.aswers = new int[3];
        foreach(GameObject s in strols)
        {
            s.SetActive(false);
        }
    }

    #region DropObject
    void DropObject()
    {
        isSelect = false;
        gameController.isPick = false;
        // Cursor.visible = true;
        if (onPaper && !quit)
        {
            switch (myType)
            {
                case "Stamp":
                        QuitScreen();
                        PropsAffect();
   
                    break;
            }
        }
       

    }
    #endregion
    
    #region OnTriggerEnterAndExit
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Paper"))
        {
            onPaper = true;
            paper = coll.gameObject;

        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Paper"))
        {
            onPaper = false;
            if (!quit) paper = null;
        }
    }
    #endregion

    void Update ()
    {
        if(!gameController.FinaleDay && !gameController.fade)
        {
             RayCast();

            if (isSelect)
            {
                FollowMouse();
                if (Input.GetMouseButtonUp(0)) DropObject();
            }
            if(!isSelect)
                this.transform.position = Vector2.Lerp(this.transform.position, inicialPos, 0.05f);
         

            if (paper != null && quit.Equals(true) && myType.Equals("Stamp"))
                if(paper.transform.position.x < 14)
                    paper.transform.position = Vector2.Lerp(paper.transform.position, new Vector2(15, 1), 0.05f);
            else if (myType.Equals("Stamp"))
            {
                Destroy(paper);
                paper = null;
                gameController.OnCreate();
                quit = false;
            }
        }
    }
    #region RayCast
    void RayCast()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 ray = getWorldPosition(Input.mousePosition);
            RaycastHit2D[] hits;
            hits = Physics2D.RaycastAll(ray, new Vector2(0, 0));

            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit2D hit = hits[i];
                if (hit.collider.gameObject != null)
                {
                    if (hit.collider != null && hit.collider.isTrigger && hit.collider.gameObject.Equals(this.gameObject) && !gameController.isPick)
                    {
                        isSelect = true;
                        gameController.isPick = true;
                    }
                }

                else
                {
                    isSelect = false;
                }
            }
        }
    }
    #endregion

    #region FallowMouse
    private void FollowMouse()
    {
        mousePos = getWorldPosition(Input.mousePosition);
        this.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
    }
    #endregion
    private void QuitScreen()
    {
        if (paper != null) quit = true;
    }
    

    private void PropsAffect()
    {
        if (this.aprove)
        {
            gameController.props += paper.GetComponent<PaperController>().GetEffectsProps();
            if (gameController.props.x < 8 && paper.GetComponent<PaperController>().GetEffectsProps().x > 0)
            {
                bars[0].PosDesactive();
                tutorial.ChangeFace(true);
                GameController.aswers[actual] = 1;
                if(actual.Equals(0))
                    strols[0].SetActive(true);
                if (actual.Equals(1))
                    strols[2].SetActive(true);
                if (actual.Equals(2))
                    strols[4].SetActive(true);
            }
            if (paper.GetComponent<PaperController>().GetEffectsProps().x < 0)
            {
                bars[0].DecDesactive();
                tutorial.ChangeFace(false);
                GameController.aswers[actual] = 0;
                if (actual.Equals(0))
                    strols[1].SetActive(true);
                if (actual.Equals(1))
                    strols[3].SetActive(true);
                if (actual.Equals(2))
                    strols[5].SetActive(true);
            }
            if (gameController.props.y < 8 && paper.GetComponent<PaperController>().GetEffectsProps().y > 0)
            {
                bars[1].PosDesactive();
                tutorial.ChangeFace(true);
                GameController.aswers[actual] = 1;
                if (actual.Equals(0))
                    strols[0].SetActive(true);
                if (actual.Equals(1))
                    strols[2].SetActive(true);
                if (actual.Equals(2))
                    strols[4].SetActive(true);
            }
            if (paper.GetComponent<PaperController>().GetEffectsProps().y < 0)
            {
                bars[1].DecDesactive();
                tutorial.ChangeFace(false);
                GameController.aswers[actual] = 0;
                if (actual.Equals(0))
                    strols[1].SetActive(true);
                if (actual.Equals(1))
                    strols[3].SetActive(true);
                if (actual.Equals(2))
                    strols[5].SetActive(true);
            }
            if (gameController.props.z < 8 && paper.GetComponent<PaperController>().GetEffectsProps().z > 0)
            {
                bars[2].PosDesactive();
                tutorial.ChangeFace(true);
                GameController.aswers[actual] = 1;
                if (actual.Equals(0))
                    strols[0].SetActive(true);
                if (actual.Equals(1))
                    strols[2].SetActive(true);
                if (actual.Equals(2))
                    strols[4].SetActive(true);
            }
            if (paper.GetComponent<PaperController>().GetEffectsProps().z < 0)
            {
                bars[2].DecDesactive();
                tutorial.ChangeFace(false);
                GameController.aswers[actual] = 0;
                if (actual.Equals(0))
                    strols[1].SetActive(true);
                if (actual.Equals(1))
                    strols[3].SetActive(true);
                if (actual.Equals(2))
                    strols[5].SetActive(true);
            }
            if (!gameController.checkProps) gameController.checkProps = true;
            // gameController.UpFeedBack();
            auxProps = Vector3.zero;
        }
        else
        {
            if (gameController.props.x < 8 && paper.GetComponent<PaperController>().GetEffectsProps().x > 0)
            {
                tutorial.ChangeFace(false);
                GameController.aswers[actual] = 0;
                if (actual.Equals(0))
                    strols[1].SetActive(true);
                if (actual.Equals(1))
                    strols[3].SetActive(true);
                if (actual.Equals(2))
                    strols[5].SetActive(true);
            }
            if (paper.GetComponent<PaperController>().GetEffectsProps().x < 0)
            {
                tutorial.ChangeFace(true);
                GameController.aswers[actual] = 1;
                if (actual.Equals(0))
                    strols[0].SetActive(true);
                if (actual.Equals(1))
                    strols[2].SetActive(true);
                if (actual.Equals(2))
                    strols[4].SetActive(true);
            }
            if (gameController.props.y < 8 && paper.GetComponent<PaperController>().GetEffectsProps().y > 0)
            {
                tutorial.ChangeFace(false);
                GameController.aswers[actual] = 0;
                if (actual.Equals(0))
                    strols[1].SetActive(true);
                if (actual.Equals(1))
                    strols[3].SetActive(true);
                if (actual.Equals(2))
                    strols[5].SetActive(true);
            }
            if (paper.GetComponent<PaperController>().GetEffectsProps().y < 0)
            {
                tutorial.ChangeFace(true);
                GameController.aswers[actual] = 1;
                if (actual.Equals(0))
                    strols[0].SetActive(true);
                if (actual.Equals(1))
                    strols[2].SetActive(true);
                if (actual.Equals(2))
                    strols[4].SetActive(true);
            }
            if (gameController.props.z < 8 && paper.GetComponent<PaperController>().GetEffectsProps().z > 0)
            {
                tutorial.ChangeFace(false);
                GameController.aswers[actual] = 0;
                if (actual.Equals(0))
                    strols[1].SetActive(true);
                if (actual.Equals(1))
                    strols[3].SetActive(true);
                if (actual.Equals(2))
                    strols[5].SetActive(true);
            }
            if (paper.GetComponent<PaperController>().GetEffectsProps().z < 0)
            {
                tutorial.ChangeFace(true);
                GameController.aswers[actual] = 1;
                if (actual.Equals(0))
                    strols[0].SetActive(true);
                if (actual.Equals(1))
                    strols[2].SetActive(true);
                if (actual.Equals(2))
                    strols[4].SetActive(true);
            }
        }
        if ((GameController.aswers[0] + GameController.aswers[1] + GameController.aswers[2]).Equals(3))
            tutorial.ChangeFinal(Vector3.one * 8);
        if ((GameController.aswers[0] + GameController.aswers[1] + GameController.aswers[2]).Equals(2))
            tutorial.ChangeFinal(Vector3.one * 7);
        if ((GameController.aswers[0] + GameController.aswers[1] + GameController.aswers[2]).Equals(1))
            tutorial.ChangeFinal(Vector3.one * 5);
        if ((GameController.aswers[0] + GameController.aswers[1] + GameController.aswers[2]).Equals(0))
            tutorial.ChangeFinal(Vector3.one * 0);
        actual++;
    }

    private void FollowMouse(Transform i)
    {
        this.GetComponent<Rigidbody2D>().MovePosition(i.position);
    }
    #region GetWorldPosition
    // Following method calculates world's point from screen point as per camera's projection type
    public Vector3 getWorldPosition(Vector3 screenPos)
    {
        Vector3 worldPos;
        if (Camera.main.orthographic)
        {
            worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            worldPos.z = Camera.main.transform.position.z;
        }
        else
        {
            worldPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, Camera.main.transform.position.z));
            worldPos.x *= -1;
            worldPos.y *= -1;
        }
        return worldPos;
    }
    #endregion

   
}
