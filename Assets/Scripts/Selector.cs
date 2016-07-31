using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Selector : MonoBehaviour {

    private bool isSelect;
    private bool onPaper;
    private bool onMouse;
    private bool quit;
    [SerializeField]
    private string myType; 
    private GameObject paper;
    private Vector3 mousePos;
  

    [SerializeField]
    private bool cooldown;
    [SerializeField]
    private float timeCollDown;

    [SerializeField]
    private GameController gameController;

 
    public static Vector3 auxProps;


    // Use this for initialization
    void Start ()
    {
        cooldown = false;
    }
 
    private bool CoolDown()
    {
        return cooldown = false;
    }
   
    #region DropObject
    void DropObject()
    {
        isSelect = false;
        gameController.isPick = false;
        // Cursor.visible = true;
        if (onPaper && !cooldown)
        {
            switch (myType)
            {
                case "Cheers":
                    if (paper != null && !paper.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled)
                    {
                        paper.transform.GetChild(2).transform.position = this.transform.position;
                        paper.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = true;
                        cooldown = true;
                        auxProps = new Vector3(1, auxProps.y, auxProps.z);
                    }
                    break;
                case "Education":
                    if (paper != null && !paper.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled)
                    {
                        paper.transform.GetChild(1).transform.position = this.transform.position;
                        paper.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
                        cooldown = true;
                        auxProps = new Vector3(auxProps.x, 1, auxProps.z);
                    }
                    break;
                case "Safety":
                    if (paper != null && !paper.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled)
                    {
                        paper.transform.GetChild(0).transform.position = this.transform.position;
                        paper.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
                        cooldown = true;
                        auxProps = new Vector3(auxProps.x, auxProps.y, 1);

                    }
                    break;
                case "Stamp":
                    if (paper != null && !paper.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled && !paper.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled && !paper.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled)
                        Debug.Log("Não está preenchida!!");
                    else
                    {
                        QuitScreen();
                        PropsAffect();

                    }
                    break;
            }
        }
        else if (onPaper) Debug.Log("CoolDown");

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
        RayCast();

        if (isSelect)
        {
            FollowMouse();
            if (Input.GetMouseButtonUp(0) && isSelect) DropObject();
           
        }
        
        if (paper != null && quit.Equals(true) && myType.Equals("Stamp"))
            if(paper.transform.position.x < 3f) paper.transform.position += new Vector3(0.05f,0,0);
        else if(myType.Equals("Stamp"))
        {
            Destroy(paper);
            paper = null;
            gameController.OnCreate();
            quit = false;
        }
        if (cooldown)
            Invoke("CoolDown", timeCollDown);
   
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
        gameController.props += auxProps;
        auxProps = Vector3.zero;
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
