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


    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private GameObject feedback;
    public static Vector3 auxProps;
    public static float multCooldown;

    void Start ()
    {      
        inicialPos = this.transform.position;
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

    void DesactivedFeedback()
    {
        feedback.SetActive(false);
    }

    private void PropsAffect()
    {
        feedback.SetActive(true);
        Invoke("DesactivedFeedback", 0.3f);
        
        if (this.aprove)
        {
            gameController.props += paper.GetComponent<PaperController>().GetEffectsProps();
            if (gameController.props.x < 8 && paper.GetComponent<PaperController>().GetEffectsProps().x > 0)
            {
                bars[0].PosDesactive();
                tutorial.ChangeFace(true);
            }
            if (paper.GetComponent<PaperController>().GetEffectsProps().x < 0)
            {
                bars[0].DecDesactive();
                tutorial.ChangeFace(false);
            }
            if (gameController.props.y < 8 && paper.GetComponent<PaperController>().GetEffectsProps().y > 0)
            {
                bars[1].PosDesactive();
                tutorial.ChangeFace(true);
            }
            if (paper.GetComponent<PaperController>().GetEffectsProps().y < 0)
            {
                bars[1].DecDesactive();
                tutorial.ChangeFace(false);
            }
            if (gameController.props.z < 8 && paper.GetComponent<PaperController>().GetEffectsProps().z > 0)
            {
                bars[2].PosDesactive();
                tutorial.ChangeFace(true);
            }
            if (paper.GetComponent<PaperController>().GetEffectsProps().z < 0)
            {
                bars[2].DecDesactive();
                tutorial.ChangeFace(false);
            }
            if (!gameController.checkProps) gameController.checkProps = true;
            // gameController.UpFeedBack();
            auxProps = Vector3.zero;
        }
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
